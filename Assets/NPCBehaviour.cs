using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;
    [SerializeField] private Vector3 min, max;
    [SerializeField] private GameObject player;
    [SerializeField] private float playerDetectionDistance;
    [SerializeField] private bool playerDetected;
    bool espera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        espera = false;
        //destination = path.GetChild(childrenIndex).position;
       // destination = RandomDestination();
        //GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerDetected && !espera){
            espera = true;
            destination = player.transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
            StartCoroutine(Espera());
        }
    }

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }

    IEnumerator Espera()
    {
 
        yield return new WaitForSeconds(2f);
        espera = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
            destination = other.transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }
    }


}
