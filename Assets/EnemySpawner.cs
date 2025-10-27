using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 5f;
    public float spawnRadius = 10f; // Radius around the spawner
    public string newTag = "Enemy";

    public void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 randomPosition = new Vector3(transform.position.x + randomCircle.x, transform.position.y, transform.position.z + randomCircle.y);

        Instantiate(prefab, randomPosition, Quaternion.identity);
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnDelay);
    }

    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
