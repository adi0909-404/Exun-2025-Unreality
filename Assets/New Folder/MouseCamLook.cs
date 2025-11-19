using UnityEngine;

public class MouseCamLook : MonoBehaviour
{
    public float sensitivity = 5f;
    public float smoothing = 2f;

    private Vector2 mouseLook;
    private Vector2 smoothV;
    private Transform playerBody;

    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector2 rawMouse = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 scaledMouse = rawMouse * sensitivity * smoothing;

        smoothV.x = Mathf.Lerp(smoothV.x, scaledMouse.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, scaledMouse.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f); // vertical clamp

        // Rotate camera (pitch)
        transform.localRotation = Quaternion.Euler(-mouseLook.y, 0f, 0f);

        // Rotate player (yaw)
        playerBody.localRotation = Quaternion.Euler(0f, mouseLook.x, 0f);
    }
}
