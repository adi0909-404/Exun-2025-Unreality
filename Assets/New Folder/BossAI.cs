using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 25;
    public float attackRange = 3f;
    public float meleeCooldown = 1f;
    public int health = 200;

    public GameObject projectile;
    public float rainCooldown = 5f;
    public int rainCount = 10;
    public float rainRadius = 5f;
    public float rainHeight = 10f;

    Transform player;
    float lastMelee, lastRain;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!player) return;

        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) <= attackRange && Time.time > lastMelee + meleeCooldown)
        {
            player.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            lastMelee = Time.time;
        }

        if (Time.time > lastRain + rainCooldown)
        {
            Rain();
            lastRain = Time.time;
        }
    }

    void Rain()
    {
        for (int i = 0; i < rainCount; i++)
        {
            Vector3 pos = player.position + new Vector3(Random.Range(-rainRadius, rainRadius), rainHeight, Random.Range(-rainRadius, rainRadius));
            var proj = Instantiate(projectile, pos, Quaternion.identity);
            proj.GetComponent<Rigidbody>().linearVelocity = Vector3.down * 10f;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }
}
