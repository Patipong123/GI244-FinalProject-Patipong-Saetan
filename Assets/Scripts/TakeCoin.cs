using UnityEngine;
using TMPro;


public class TakeCoin : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    private int coin = 0;


    void Start()
    {
        UpdateCoinText();
    }


    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            
            coin += 1;
            UpdateCoinText();
            ObjectPooling.GetInstance().ReturnToCoinPool(other.gameObject);
        }

    }

    private void UpdateCoinText()
    {
        coinText.text = ": " + coin.ToString();
    }
}
