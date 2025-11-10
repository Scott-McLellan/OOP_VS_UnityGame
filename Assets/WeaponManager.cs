using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public float shootInterval = 3f;
    public float unlockXp = 50f;

    private bool rangedUnlocked = false;
    private float shootTimer = 0f;

    private PlayerXp playerXp;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerXp = GetComponent<PlayerXp>();
        playerHealth = GetComponent<PlayerHealth>();

       
    }

    void Update()
    {
        if (playerXp == null || playerHealth == null || shootPoint == null)
            return;

        if (playerHealth.isDead)
            return;

        if (!rangedUnlocked && playerXp.currentXp >= unlockXp)
        {
            rangedUnlocked = true;
            Debug.Log("Auto-shoot unlocked!");
        }

        if (rangedUnlocked)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                ShootArrow();
                shootTimer = 0f;
            }
        }
    }

    private void ShootArrow()
    {
        if (arrowPrefab == null)
        {
            Debug.LogError("WeaponManager: Arrow Prefab not assigned!");
            return;
        }

        Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
        Debug.Log("Arrow fired!");
    }
}