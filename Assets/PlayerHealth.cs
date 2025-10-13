using UnityEngine;

public class PlayerHealth : Health
{
    
    public int health;

    public int maxHealth = 100;
    
    public override void Die()
    {
        Time.timeScale = 0f; //When the player dies, the game pauses for now.
        Debug.Log("The Player is Dead");
        Destroy(gameObject);
    }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current Health: " + currentHealth);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
