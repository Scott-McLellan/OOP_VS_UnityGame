using TMPro;
using UnityEngine;

public class PlayerHealth : Health
{

    public TextMeshProUGUI healthText;

    public float invincibilityDuration = 1.0f;
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;

    public override void Die()
    {
        Debug.Log("Player has died!");

        if (gameOverScreen != null)
        {
            gameOverScreen.ShowGameOver();
            Debug.Log("ShowGameOver() called from PlayerHealth!");
        }
        else
        {
            Debug.LogWarning("PlayerHealth: GameOverScreen not assigned!");
        }
        isDead = true;
    }

    //sfujiugugsdhfsjfdsfdsds

    public override void TakeDamage(int damageAmount)
    {

        if (isInvincible)
            return;
        base.TakeDamage(damageAmount);
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current Health: " + currentHealth);
        UpdateHealthText();

        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        StartCoroutine(FlashSprite());

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
        
        if (gameOverScreen == null)
        {
            gameOverScreen = FindFirstObjectByType<GameOverScreen>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
                isInvincible = false;
        }
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }



    public void ResetHealth()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthText();
    }

    private System.Collections.IEnumerator FlashSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) yield break;

        Color originalColor = sr.color;
        for (int i = 0; i < 5; i++)
        {
            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.3f);
            yield return new WaitForSeconds(0.1f);
            sr.color = originalColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
