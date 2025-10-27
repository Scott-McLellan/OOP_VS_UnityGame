using UnityEngine;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    [Header("References")]
    public GameObject[] backgroundPrefabs; 
    private Transform playerTransform;
    private Camera mainCam;

    [Header("Settings")]
    public float tileWidth = 20f; 
    public float tileHeight = 20f; 
    public float buffer = 2f;      

    private Dictionary<Vector2Int, GameObject> activeTiles = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        mainCam = Camera.main;

        if (playerTransform == null || mainCam == null)
        {
            Debug.LogError("BackgroundManager: Missing Player or Main Camera reference!");
            enabled = false;
            return;
        }

        UpdateTiles();
    }

    void Update()
    {
        if (playerTransform == null) return;
        UpdateTiles();
    }

    void UpdateTiles()
    {
        Vector3 camBottomLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 camTopRight = mainCam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        int xStart = Mathf.FloorToInt((camBottomLeft.x - buffer) / tileWidth);
        int xEnd   = Mathf.CeilToInt((camTopRight.x + buffer) / tileWidth);
        int yStart = Mathf.FloorToInt((camBottomLeft.y - buffer) / tileHeight);
        int yEnd   = Mathf.CeilToInt((camTopRight.y + buffer) / tileHeight);

        HashSet<Vector2Int> neededTiles = new HashSet<Vector2Int>();

        for (int x = xStart; x <= xEnd; x++)
        {
            for (int y = yStart; y <= yEnd; y++)
            {
                Vector2Int tileCoord = new Vector2Int(x, y);
                neededTiles.Add(tileCoord);

                if (!activeTiles.ContainsKey(tileCoord))
                {
                    SpawnTile(tileCoord);
                }
            }
        }

        List<Vector2Int> toRemove = new List<Vector2Int>();
        foreach (var kvp in activeTiles)
        {
            if (!neededTiles.Contains(kvp.Key))
            {
                Destroy(kvp.Value);
                toRemove.Add(kvp.Key);
            }
        }

        
        foreach (var key in toRemove)
        {
            activeTiles.Remove(key);
        }
    }

    void SpawnTile(Vector2Int coord)
    {
        int index = Random.Range(0, backgroundPrefabs.Length);
        Vector3 pos = new Vector3(coord.x * tileWidth, coord.y * tileHeight, 0);
        GameObject newTile = Instantiate(backgroundPrefabs[index], pos, Quaternion.identity);
        activeTiles.Add(coord, newTile);
    }
}
