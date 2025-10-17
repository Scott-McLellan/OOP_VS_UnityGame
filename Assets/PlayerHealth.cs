using UnityEngine;

public class PlayerHealth : Health
{
    public override void Die()
    {
        Time.timeScale = 0f; //When the player dies, the game pauses for now.
        Debug.Log("The Player is Dead");
        Destroy(gameObject);
    }
    
    //sfujiugugsdhfsjfdsfdsds
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
        Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current Health: " + currentHealth);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        health = maxHealth;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
