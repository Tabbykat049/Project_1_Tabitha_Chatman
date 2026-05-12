using UnityEngine;
using UnityEngine.SceneManagement;


public class New_Level_Trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the Player entered the endzone
        if (other.CompareTag("Player"))
        {
            // 2. Check if all "PickUp" objects are gone
            if (GameObject.FindGameObjectsWithTag("PickUp").Length == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                Debug.Log("You still have pickups left to collect!");
            }
        }
    }
}