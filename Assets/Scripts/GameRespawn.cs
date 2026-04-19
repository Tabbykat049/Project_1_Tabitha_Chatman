using UnityEngine;

public class GameRespawn : MonoBehaviour 
{ 
    public GameObject Player; 

    private void OnTriggerEnter(Collider other) 
    { 
        if (other.gameObject.CompareTag("Player")) 
        { 
            GameObject playerRoot = other.gameObject;
            
            // 1. Get the Health component using 'other' instead of 'collision'
            PlayerHealth playerHealth = playerRoot.GetComponent<PlayerHealth>(); 
            if (playerHealth != null) 
            { 
                playerHealth.TakeDamage(20); 
            } 

            // 2. Handle the teleportation
            CharacterController cc = playerRoot.GetComponent<CharacterController>();
            if (cc != null) 
            { 
                cc.enabled = false; // Disable to allow manual position change
                playerRoot.transform.position = new Vector3(3.87f, 1.2f, -2.28f); 
                cc.enabled = true; 
            } 
        } 
    } 
}