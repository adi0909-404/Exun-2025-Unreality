using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHP = 50;
    int currentHP;

    public Renderer body;       // assign in Inspector
    public Color hitColor = Color.red;
    public float flashTime = 0.1f;

    Color originalColor;

    void Start()
    {
        currentHP = maxHP;
        if (body != null)
            originalColor = body.material.color;
    }

    public void TakeDamage(int dmg, Vector3 hitPoint, Vector3 hitNormal)
    {
        currentHP -= dmg;

        if (body != null)
        {
            body.material.color = hitColor;
            CancelInvoke(nameof(ResetColor));
            Invoke(nameof(ResetColor), flashTime);
        }

        if (currentHP <= 0)
            Die();
    }

    void ResetColor()
    {
        if (body != null)
            body.material.color = originalColor;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
