using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.5f;
    public float attackRange = 2f;
    public float attackCooldown = 1.2f;
    public int damage = 10;

    Transform player;
    float lastAttack;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (!player) return;
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(player);
        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time > lastAttack + attackCooldown)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            lastAttack = Time.time;
        }
    }
}
