using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    float currentHealth;
    public Slider healthBar;
    public string gameOverScene = "GameOver";

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (currentHealth <= 0)
            StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        float duration = 1f; 
        float elapsed = 0f;
        Vector3 originalScale = transform.localScale;

        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, Vector3.zero, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = Vector3.zero;

        SceneManager.LoadScene(gameOverScene);
    }
}
