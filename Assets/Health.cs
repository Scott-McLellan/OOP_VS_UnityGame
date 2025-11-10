using UnityEngine;

public class Health : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    public bool isDead = false;

    public int currentHealth;
    public int maxHealth = 100;

    public virtual void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        isDead = true;
        Destroy(gameObject);
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

    public virtual void Start()
    {
        currentHealth = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
