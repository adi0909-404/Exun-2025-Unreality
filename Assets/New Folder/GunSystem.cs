using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public Transform gunHold;        // empty child under Camera
    public GameObject bulletPrefab;  // assign in Inspector
    public float bulletSpeed = 25f;

    GameObject heldGun;
    Transform firePoint;

    void Update()
    {
        HandlePickup();
        HandleShooting();
    }

    void HandlePickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                if (hit.collider.CompareTag("Gun") && heldGun == null)
                {
                    heldGun = hit.collider.gameObject;
                    heldGun.transform.SetParent(gunHold);
                    heldGun.transform.localPosition = Vector3.zero;
                    heldGun.transform.localRotation = Quaternion.identity;

                    // Grab FirePoint from gun prefab
                    firePoint = heldGun.transform.Find("FirePoint");

                    Destroy(heldGun.GetComponent<Rigidbody>());
                    Destroy(heldGun.GetComponent<Collider>());
                }
            }
        }
    }

    void HandleShooting()
    {
        if (heldGun != null && Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
}
