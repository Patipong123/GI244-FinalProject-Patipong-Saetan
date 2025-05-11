using UnityEngine;

public class FlipCameraView : MonoBehaviour
{
    public TakePoint takePoint;
    private bool isFlipped = false;

    void Update()
    {
        if (takePoint != null)
        {
            if (takePoint.GetScore() >= 10 &&  takePoint.GetScore() < 15 && !isFlipped)
            {
                FlipCamera(); 
                isFlipped = true;
            }
            else if (takePoint.GetScore() >= 15 && isFlipped)
            {
                FlipCamera(); 
                isFlipped = false;
            }

        }
    }

    

    void FlipCamera()
    {
        Camera.main.transform.Rotate(0f, 0f, 180f);
<<<<<<< HEAD
        Debug.Log("Camera flipped!");
=======
        
>>>>>>> ็HighScore
    }
}
