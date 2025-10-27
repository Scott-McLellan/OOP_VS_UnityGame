using UnityEngine;


public class EnemyHealth : Health
{
    
    public GameObject prefab;
    public override void Die()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        Debug.Log(gameObject.name + " has been defeated!");
        ScoreManager.Instance.AddScore(50);
        base.Die(); 
    }
    
    public override void TakeDamage(int damageAmount)
    {
       base.TakeDamage(damageAmount);
       Debug.Log(gameObject.name + " took " + damageAmount + " damage. Current Health: " + currentHealth);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /*void Start()
    {
        health = maxEnemyHealth;
    }*/

    // Update is called once per frame
  
}
