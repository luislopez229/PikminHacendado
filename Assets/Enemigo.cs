using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{  
    
    private Transform player;
    private NavMeshAgent agent;
    private Vector3 posInicial;
        public float rangoPatrulla = 5f;
    public float detectionRange = 5f;
    public float rangoPerder = 8f;
    public float velPatrulla = 2f;
    public float velSeguir = 4f;
      public enum State { Patrulla, Seguir, Buscando }
    private State estadoActual;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        estadoActual = State.Patrulla;
        agent.speed = velPatrulla;
        posInicial = transform.position;
        PatrullaAleatoria();
    }

    void Update()
    {
        switch (estadoActual)
        {
            case State.Patrulla:
                Patrulla();
                break;
            case State.Seguir:
                SeguirJugador();
                break;
            case State.Buscando:
                Buscando();
                break;
        }
    }

    void Patrulla()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            PatrullaAleatoria();
        }

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            estadoActual = State.Seguir;
            agent.speed = velSeguir;
        }
    }

    void SeguirJugador()
    {
        agent.destination = player.position;

        if (Vector3.Distance(transform.position, player.position) > rangoPerder)
        {
            estadoActual = State.Buscando;
            agent.speed = velSeguir;
        }
    }

    void Buscando()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            PatrullaAleatoria();
            agent.speed = velSeguir;
        }

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            estadoActual = State.Seguir;
            agent.speed = velSeguir;
        }
    }

    void PatrullaAleatoria()
    {
        Vector3 randomDirection = Random.insideUnitSphere * rangoPatrulla;
        randomDirection += posInicial;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, rangoPatrulla, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }
    }
}
