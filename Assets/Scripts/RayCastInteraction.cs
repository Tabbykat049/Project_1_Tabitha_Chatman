using UnityEngine;
using UnityEngine.EventSystems; // Required to detect UI

public class RayCastInteraction : MonoBehaviour
{
    private GameObject mainCamera;

    void Start()
    {
        mainCamera = FindFirstObjectByType<Camera>().gameObject;
    }

    void Update()
    {
        // 1. Check if the mouse is clicking on a UI element (like your buttons)
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return; // Exit Update and do nothing if we are clicking a button
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                if (hit.transform.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(mainCamera.transform.forward * 1000f);
                }
            }
        }
    }
}