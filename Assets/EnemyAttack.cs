using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private PlayerHealth playerHealth; 
    Transform target;
    
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

            if (dist < 1)
            {
                playerHealth.TakeDamage(10);
            }
        }
    }
}
