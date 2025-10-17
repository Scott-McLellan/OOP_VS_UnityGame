using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float playerattackCooldown = 0.7f;
    private float playerattackCooldownTimer;


    public bool canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!canAttack)
        {
            playerattackCooldownTimer -= Time.deltaTime;
            if (playerattackCooldownTimer <= 0f)
            {
                canAttack = true;
            }
        }

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyHealth[] enemyHealths = new EnemyHealth[enemyObjects.Length];
        int i = 0;
        foreach (GameObject o in enemyObjects)
        {
            enemyHealths[i] = o.GetComponent<EnemyHealth>();
            i++;
        }

        foreach (EnemyHealth enemy in enemyHealths)
        {
            float dist = ScottMath.GetDistance(transform.position, enemy.transform.position);

            if (dist < 2 && canAttack)
            {
                Attack(enemy);
            }
        }
        
    }
    
    void Attack(EnemyHealth enemy)
    {
        Debug.Log("Enemy is Attacking");
        playerattackCooldownTimer = playerattackCooldown;
        canAttack = false;
        enemy.TakeDamage(10);
    }
}
