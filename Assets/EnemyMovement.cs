using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isDead = false;
    
    public int PlayerMaxHealth = 100;
    public int PlayerCurrentHealth;
    
    private Transform target;
    public float enemySpeed;

   
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        PlayerCurrentHealth = PlayerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        { 
            
            
            //move
            Vector2 direction = (target.position - transform.position).normalized;
            Vector3 direction3D = new Vector3(direction.x, direction.y, 0);
            transform.position += direction3D * enemySpeed * Time.deltaTime;
        }
        
    }
}
