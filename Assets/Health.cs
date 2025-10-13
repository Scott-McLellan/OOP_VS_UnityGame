using UnityEngine;

public class Health : MonoBehaviour
{
    public bool isDead = false;
    
    public int currentHealth;
    public int maxHealth = 100;
    
    public virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        Destroy(gameObject);
        isDead = true;
    }
    
    
    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
