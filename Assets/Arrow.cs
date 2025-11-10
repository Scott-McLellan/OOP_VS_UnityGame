using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    public float speed = 10f;       
    public float lifetime = 10f;    
    public float hitRange = 10f;     
    public int damage = 10; 
    private SpriteRenderer spriteRenderer;
    
    private float moveDirection = 1f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        PlayerMovement playerMovement = null;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            if (playerMovement.isFacingLeft == true)
            {
                spriteRenderer.flipX = true;
                moveDirection = -1f;
            }
            else
            {
                spriteRenderer.flipX = false;
                moveDirection = 1f;
            }
        }
       

        Destroy(gameObject, lifetime);

    }

    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime * moveDirection, 0.0f, 0.0f);

        CheckForEnemyHit();
    }

    private void CheckForEnemyHit()
    {
        
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        Debug.Log($"Arrow checking {enemies.Length} enemies");

        foreach (GameObject enemyObj in enemies)
        {
            if (enemyObj == null) continue;

            float dist = Vector3.Distance(transform.position, enemyObj.transform.position);

            if (dist < hitRange)
            {
                Debug.Log($"Arrow hit {enemyObj.name} at distance {dist:F2}");
                Health enemyHealth = enemyObj.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                    Debug.Log($"Arrow hit {enemyObj.name} for {damage} damage");
                }

                Destroy(gameObject);
                break; 
            }
        }
    }
}