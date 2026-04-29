using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
    public int GetScore()
    {
        return score;
    }
}
