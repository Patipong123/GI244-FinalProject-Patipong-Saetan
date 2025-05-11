using UnityEngine;
using System.Collections;

public class Immortal : MonoBehaviour
{
    public float immortalDuration = 5f;
    public GameObject immortalUIText; 

    private PlayerController playerController;
    private EnegyController energyController;
    private Coroutine currentImmortalCoroutine;

    private float originalDecreaseRate;

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        energyController = FindAnyObjectByType<EnegyController>();

        if (energyController != null)
        {
            originalDecreaseRate = energyController.decreaseRate;
        }

        if (immortalUIText != null)
        {
            immortalUIText.SetActive(false); 
        }
    }

    public void ActivateImmortal()
    {
        if (currentImmortalCoroutine != null)
        {
            StopCoroutine(currentImmortalCoroutine);
        }

        currentImmortalCoroutine = StartCoroutine(ImmortalRoutine());
    }

    IEnumerator ImmortalRoutine()
    {
        

        playerController.SetImmortal(true);
        energyController.decreaseRate = 0f;

        if (immortalUIText != null)
        {
            immortalUIText.SetActive(true);
        }

        yield return new WaitForSeconds(immortalDuration);

        playerController.SetImmortal(false);
        energyController.decreaseRate = originalDecreaseRate;

        if (immortalUIText != null)
        {
            immortalUIText.SetActive(false);
        }

        
    }
}
