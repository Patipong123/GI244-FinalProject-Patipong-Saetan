using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TakePoint : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    
    

    void Start()
    {
        scoreManager.ResetScore();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TakePoint"))
        {
            scoreManager.AddScore(1);
        }
        
    }


    public int GetScore()
    {
        return scoreManager != null ? scoreManager.GetCurrentScore() : 0;
    }
}
