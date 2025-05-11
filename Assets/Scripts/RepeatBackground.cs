using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float width;
    private PlayerController player;

    public float normalSpeed = 5f;
    public float boostedSpeed = 15f;
    private float currentSpeed;

    void Start()
    {
        startPos = transform.position;
        width = GetComponent<Renderer>().bounds.size.x;

        player = FindAnyObjectByType<PlayerController>();
    }

    void Update()
    {
        if (player == null || player.isGameOver)
            return;

        
        currentSpeed = player.IsImmortal() ? boostedSpeed : normalSpeed;

        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < startPos.x - width)
        {
            transform.position = startPos;
        }
    }
}
