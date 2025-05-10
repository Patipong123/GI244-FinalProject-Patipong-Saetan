using UnityEngine;
using TMPro;


public class TakePoint : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    

    void Start()
    {
        UpdateScoreText();
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TakePoint"))
        {
            score += 1;
            UpdateScoreText();
        }
        
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
