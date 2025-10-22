using UnityEngine;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private float despawnDistance = 10f;  // Editable in Inspector
    private Transform playerTransform;
    private List<GameObject> backgrounds = new List<GameObject>();

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Cache all background objects once
        GameObject[] backgroundObjects = GameObject.FindGameObjectsWithTag("Background");
        backgrounds.AddRange(backgroundObjects);
    }

    void Update()
    {
        if (playerTransform == null) return;

        // Iterate backwards so we can safely remove from the list
        for (int i = backgrounds.Count - 1; i >= 0; i--)
        {
            GameObject b = backgrounds[i];
            if (b == null)
            {
                backgrounds.RemoveAt(i);
                continue;
            }

            float dist = Vector3.Distance(b.transform.position, playerTransform.position);

            if (dist > despawnDistance)
            {
                Destroy(b);
                backgrounds.RemoveAt(i);
            }
        }
    }
}