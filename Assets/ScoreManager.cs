using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score { get; private set; } = 0;

    [SerializeField] private TextMeshProUGUI scoreText; //For the UI

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + Score;
    }

    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        Score += amount;
        Debug.Log("Score: " + Score);

        if (scoreText != null)
            scoreText.text = "Score: " + Score;
    }

    public void ResetScore()
    {
        Score = 0;
        if (scoreText != null)
            scoreText.text = "Score: " + Score;
    }
}