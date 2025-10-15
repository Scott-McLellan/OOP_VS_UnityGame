using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

            if (dist < 2)
            {
                //enemy.TakeDamage(15);
            }
        }
    }
}
