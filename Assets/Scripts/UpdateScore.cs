using TMPro;
using UnityEngine;
using UnityEngine.UI; // Only if you're using UI Text

public class UpdateScore : MonoBehaviour
{
    public static UpdateScore Instance { get; private set; }

    private int score;
    private int enemyCount;

    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the UI Text for displaying the score
    [SerializeField] private TextMeshProUGUI enemyCountText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void UpdateEnemyCount(int count)
    {
        enemyCount = count;
        if (enemyCountText != null)
        {
            enemyCountText.text = "Active Enemies: " + enemyCount.ToString();
        }
        
        
        
    }
}
