using TMPro;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    private float startingXp = 0f;
    public float currentXp;

    public TextMeshProUGUI xpText;

    public void AddXp(float xpGain)
    {
        currentXp += xpGain;
        UpdateXPText();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        currentXp = startingXp;
        if (xpText != null)
            xpText.text = "XP: " + currentXp;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void UpdateXPText()
    {
        if (xpText != null)
            xpText.text = "XP: " + currentXp;
    }
}
