using UnityEngine;

public class LockedRoom : MonoBehaviour
{
    [SerializeField] private scoreUI scoreManager; // Drag your Score object here
    

    void Update()
    {
       if (scoreUI.Score >= 5) { // Access directly via the class name
        Destroy(gameObject);
    }
    }
}
