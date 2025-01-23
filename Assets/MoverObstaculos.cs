using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObstaculos : MonoBehaviour
{
    // Start is called before the first frame update
    bool volviendo;
    public Vector3 posFinal;
    Vector3 posInicial;

    float velocidad = 6f;
    void Start()
    {
        posInicial = transform.position;
        volviendo = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = volviendo ? posFinal : posInicial;

        transform.position = Vector3.MoveTowards(transform.position, destination, velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, destination) < 0.01f)
        {
            volviendo = !volviendo;
        }

    }
}