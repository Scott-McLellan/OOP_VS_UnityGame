using UnityEngine;

public class XpOrb : MonoBehaviour
{
    private Transform playerDistance;
    private PlayerXp playerExp;


    public float XpAmmount = 5;
    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player").transform;
        playerExp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerXp>();
    }

    void Update()
    {
        if (playerDistance == null || playerExp == null)
            return;
        
        float playerDT = Vector3.Distance(transform.position, playerDistance.position);

        if (playerDT < 0.75)
        {
            playerExp.AddXp(XpAmmount);
            Destroy(gameObject);
        }
    }
}
