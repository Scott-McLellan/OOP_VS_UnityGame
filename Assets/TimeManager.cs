using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
    private int startingTime = 0;

    string FormatTime(float time)
    {
        int mins =  Mathf.FloorToInt(time / 60);
        int secs = Mathf.FloorToInt(time % 60);
        
        return string .Format("{0:00}:{1:00}", mins, secs);
    }
    
    public static float GameTime { get; private set; }
    
    [SerializeField] private TextMeshProUGUI timeText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;

        if (timeText != null)
        {
            timeText.text = FormatTime(GameTime);
        }
    }
}
