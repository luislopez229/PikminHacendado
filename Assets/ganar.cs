using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ganar : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            SceneManager.LoadScene(1);
        }
    }

    public void volver(){
        SceneManager.LoadScene(0);
    }
}
