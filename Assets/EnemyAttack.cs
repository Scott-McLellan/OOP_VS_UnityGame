using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackCooldown = 0.5f;
    public float attackTimer;
    public bool canAttack = true;
    private PlayerHealth playerHealth; 
    Transform target;

    void Attack()
    {
        Debug.Log("Enemy is Attacking");
        attackTimer = attackCooldown;
        canAttack = false;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth =  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        target = playerHealth.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // aatack
            float dist = ScottMath.GetDistance(transform.position, target.position);
            
            if (dist < 1 && canAttack)
            {
                Attack();
                playerHealth.TakeDamage(10);
            }

            if (!canAttack)
            {
                attackTimer -= Time.deltaTime;
                if (attackTimer <= 0f)
                {
                    canAttack = true;
                }
            }
            
        }
    }
}
