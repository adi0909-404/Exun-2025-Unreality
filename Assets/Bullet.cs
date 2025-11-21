using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.CompareTag("Enemy"))
        {
            var enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null && hit.contacts.Length > 0)
            {
                Vector3 hitPoint = hit.contacts[0].point;
                Vector3 hitNormal = hit.contacts[0].normal;
                enemy.TakeDamage(10, hitPoint, hitNormal);
            }
        }
        Destroy(gameObject);
    }
}