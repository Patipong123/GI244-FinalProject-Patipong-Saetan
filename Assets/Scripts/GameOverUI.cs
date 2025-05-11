using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false); 
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true); 
        
    }

    public void RetryGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
