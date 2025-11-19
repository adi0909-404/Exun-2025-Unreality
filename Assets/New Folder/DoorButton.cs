using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public SlidingDoor door;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                if (hit.collider.gameObject == gameObject && door != null)
                    door.Toggle();
            }
        }
    }
}
