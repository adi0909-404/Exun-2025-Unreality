using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    public Camera cam;
    public float speed = 6f;
    public float sensitivity = 2f;
    public float jumpForce = 7f;

    Rigidbody rb;
    Vector2 input;
    float pitch;
    bool jump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, 1.1f))
            jump = true;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        pitch = Mathf.Clamp(pitch - mouseY, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        Vector3 move = transform.forward * input.y + transform.right * input.x;
        rb.MovePosition(rb.position + move.normalized * speed * Time.fixedDeltaTime);

        if (jump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }
}
