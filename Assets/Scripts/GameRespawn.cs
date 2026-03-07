using UnityEngine;

public class GameRespawn : MonoBehaviour
{
public GameObject Player;
private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag("Player"))
        {
            GameObject playerRoot = other.gameObject;
            CharacterController cc = playerRoot.GetComponentInChildren<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                playerRoot.transform.position = new Vector3(3.87f, 1.2f, -2.28f);
                cc.enabled = true;
            }
        }
    }
}