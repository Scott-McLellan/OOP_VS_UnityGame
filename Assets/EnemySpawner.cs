using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 5f;
    public string newTag = "Enemy";
    
    public void SpawnEnemy()
    {
        // Instantiate the enemy at the spawner's position and rotation
        Instantiate(prefab, transform.position, transform.rotation);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
        prefab.tag = newTag;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
