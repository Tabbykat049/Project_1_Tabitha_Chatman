using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Settings")]
    public Transform[] waypoints;
    public float speed = 3f;
    public float detectionRange = 10f;
    public float rotationSpeed = 15f;
    
    [Header("Size & Orientation")]
    public float enemyScale = 5f; 
    public float modelRotationOffset = 180f; 

    private Transform player;
    private int index = 0;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        transform.localScale = new Vector3(enemyScale, enemyScale, enemyScale);
    }

    void Update()
    {
        Vector3 targetPos;

        if (player != null && Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            targetPos = player.position;
        }
        else if (waypoints.Length > 0)
        {
            targetPos = waypoints[index].position;
            if (Vector3.Distance(transform.position, targetPos) < 0.5f)
            {
                index = (index + 1) % waypoints.Length;
            }
        }
        else return;

        // 1. Movement
        Vector3 direction = (targetPos - transform.position).normalized;
        direction.y = 0; 
        transform.position += direction * speed * Time.deltaTime;

        // 2. Rotation
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion offset = Quaternion.Euler(0, modelRotationOffset, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation * offset, rotationSpeed * Time.deltaTime);
        }
    }

    // 3. DAMAGE LOGIC (Using your preferred method)
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
        }
    }
}