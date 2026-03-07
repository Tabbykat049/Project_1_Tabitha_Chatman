using UnityEngine;

public class pickUp : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           FindFirstObjectByType<scoreUI>().IncreaseScore();
           
            Destroy(gameObject);
        }
    }

}
