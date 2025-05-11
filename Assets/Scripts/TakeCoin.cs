using UnityEngine;
using TMPro;


public class TakeCoin : MonoBehaviour
{
    public ScoreManager scoreManager;
    
    void Start()
    {
        if (scoreManager == null)
            scoreManager = FindAnyObjectByType<ScoreManager>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            scoreManager.AddCoin(1);
            ObjectPooling.GetInstance().ReturnToCoinPool(other.gameObject);
        }

    }

}
