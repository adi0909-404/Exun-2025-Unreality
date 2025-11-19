using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public void Toggle()
{
    opening = !opening;
}

    public Vector3 openOffset = new Vector3(0, 5, 0); // slide 5 units right
    public float speed = 3f;
    bool opening = true; // force it open immediately
    Vector3 closedPos;
    Vector3 openPos;

    void Start()
    {
        closedPos = transform.position;
        openPos = closedPos + openOffset;
    }

    void Update()
    {
        if (opening)
        {
            transform.position = Vector3.Lerp(transform.position, openPos, Time.deltaTime * speed);
        }
    }
}
