using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public TextMeshProUGUI Health;
    private bool isDead;

    public GameManagerScript gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       currentHealth = maxHealth; 
       UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        // Clamp health so it doesn't go below 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        UpdateHealthUI();

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (Health != null)
        {
            Health.text = "Health: " + currentHealth;
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        gameManager.gameOver();
        // Add death logic here
    }
}

