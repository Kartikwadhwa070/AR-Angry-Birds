using UnityEngine;
using UnityEngine.UI;  // For UI elements

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;  // Reference to the UI Text element

    private int score = 0;

    void Awake()
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

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
