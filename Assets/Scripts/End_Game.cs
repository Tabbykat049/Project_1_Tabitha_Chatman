using UnityEngine;
using UnityEngine.SceneManagement;

public class End_Game : MonoBehaviour
{
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3); 
        }
    }
}
