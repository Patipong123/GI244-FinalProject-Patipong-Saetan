using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText; 

    private int currentScore = 0;
    private int highScore = 0;
    private int coin = 0;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        coin = PlayerPrefs.GetInt("Coin", 0); 

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;

        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateUI();
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        PlayerPrefs.SetInt("Coin", coin); 
        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        currentScoreText.text = "Score : " + currentScore;
        highScoreText.text = "High Score : " + highScore;
        coinText.text = " : " + coin;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }
}
