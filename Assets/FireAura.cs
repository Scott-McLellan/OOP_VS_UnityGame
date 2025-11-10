using UnityEngine;

public class FireAura : MonoBehaviour
{
    public Transform player;           
    public float pulseSpeed = 2f;     
    public float minAlpha = 0.5f;      
    public float maxAlpha = 1f;        
    public float auraScale = 2f;       

    private SpriteRenderer spriteRenderer;
    private Color baseColor;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }

        if (spriteRenderer != null)
            baseColor = spriteRenderer.color;

        transform.localScale = new Vector3(auraScale, auraScale, 1f);
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }

        float alpha = Mathf.Lerp(minAlpha, maxAlpha, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z + alpha);

        if (spriteRenderer != null)
        {
            Color newColor = baseColor;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
        }
    }
}
