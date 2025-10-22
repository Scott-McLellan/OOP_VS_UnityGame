using TMPro;
using UnityEngine;

public class PlayerHealth : Health
{
    
    public TextMeshProUGUI healthText;
    public override void Die()
    {
        Time.timeScale = 0f; //When the player dies, the game pauses for now.
        Debug.Log("The Player is Dead");
        Destroy(gameObject);
        ResetHealth();
    }
    
    //sfujiugugsdhfsjfdsfdsds
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current Health: " + currentHealth);
        UpdateHealthText();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        if (healthText != null)
            healthText.text = "Health: " + currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
