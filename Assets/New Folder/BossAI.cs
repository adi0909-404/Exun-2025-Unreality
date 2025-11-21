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
    public float projectileFallSpeed = 10f;

    Transform player;
    float lastMelee, lastRain;
    bool active = false; 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (!player || !active) return; 

        
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
            Vector3 pos = player.position + new Vector3(
                Random.Range(-rainRadius, rainRadius),
                rainHeight,
                Random.Range(-rainRadius, rainRadius)
            );

            GameObject proj = Instantiate(projectile, pos, Quaternion.identity);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.down * projectileFallSpeed;
            }
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) Destroy(gameObject);
    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            active = true; 
        }
    }
}
