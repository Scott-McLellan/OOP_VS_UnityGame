using System;
using UnityEngine;
using System.Collections;

public class EnemyHealth : Health
{
    
    IEnumerator FlashRedRoutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
    }

    public GameObject prefab;
    private SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    private Color originalColor;
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
       
       if (spriteRenderer != null)
       {
           StartCoroutine(FlashRedRoutine());
       }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; 
        }
    }
}
