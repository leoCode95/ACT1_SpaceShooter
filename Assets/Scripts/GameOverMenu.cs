using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score: " + GameManager.Instance.GetScore();
        Time.timeScale = 0f;
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}