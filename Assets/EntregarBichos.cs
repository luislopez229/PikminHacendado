using UnityEngine;
using UnityEngine.UI;

public class EntregarBichos : MonoBehaviour
{
    int contador;
    public Text texto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contador = 0;
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemigo")){
            contador++;
            texto.text = contador.ToString() + "/4";
            Destroy(other.transform.parent.gameObject);
            if(contador>=4){
                Destroy(gameObject);
            }
        }
    }
}
