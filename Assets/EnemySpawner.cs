using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnDelay = 5f; 
    public float minSpawnDelay = 1f; 
    public float speedUpInterval = 10f; 
    public float speedUpAmount = 0.5f; 
    public float spawnRadius = 10f; 

    private float nextSpawnTime = 0f;
    private float nextSpeedUpTime = 0f;

    void Start()
    {
        nextSpawnTime = TimeManager.GameTime + spawnDelay;
        nextSpeedUpTime = TimeManager.GameTime + speedUpInterval;
    }

    void Update()
    {
        
        
        if (TimeManager.GameTime >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = TimeManager.GameTime + spawnDelay;
        }

        if (TimeManager.GameTime >= nextSpeedUpTime)
        {
            SpeedUpSpawning();
            nextSpeedUpTime = TimeManager.GameTime + speedUpInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = new Vector3(transform.position.x + randomCircle.x, transform.position.y + randomCircle.y, 0);

        Instantiate(prefab, spawnPosition, Quaternion.identity);
        Debug.Log($"Spawned enemy! (Spawn delay = {spawnDelay:F2}s)");
    }

    void SpeedUpSpawning()
    {
        spawnDelay = Mathf.Max(minSpawnDelay, spawnDelay - speedUpAmount);
        Debug.Log($"Spawn rate increased! New delay: {spawnDelay:F2}s");
    }
}