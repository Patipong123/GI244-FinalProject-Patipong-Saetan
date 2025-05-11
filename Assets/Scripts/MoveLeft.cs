using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float boostedSpeed = 15f;
    private float currentSpeed;

    private PlayerController player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();

    }

    void Update()
    {
        if (player == null || player.isGameOver)
            return;

        
        currentSpeed = player.IsImmortal() ? boostedSpeed : normalSpeed;

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime, Space.World);

        if (transform.position.x < -3f)
        {
            Destroy(gameObject);
        }
    }
}
