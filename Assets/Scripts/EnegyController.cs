using UnityEngine;
using UnityEngine.UI;

public class EnegyController : MonoBehaviour
{
    public Slider energySlider;
    public float maxEnergy = 100f;
    public float decreaseRate = 5f; 

    private float currentEnergy;

    private PlayerController playerController;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        currentEnergy = maxEnergy;
        energySlider.maxValue = maxEnergy;
        energySlider.value = currentEnergy;
    }

    void Update()
    {
        if (playerController == null || playerController.isGameOver)
            return;

        if (currentEnergy > 0f)
        {
            currentEnergy -= decreaseRate * Time.deltaTime;
            currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
            energySlider.value = currentEnergy;

            if (currentEnergy <= 0f)
            {
                
                playerController.GameOver();
            }
        }
    }

    public void AddEnergy(float amount)
    {
        currentEnergy += amount;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, maxEnergy);
        energySlider.value = currentEnergy;
    }
}
