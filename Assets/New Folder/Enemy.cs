using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            transform.position += dir * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.CompareTag("Player"))
        {
            hit.collider.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
