using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;
    public bool isGameOver = false;
    private Rigidbody rb;
    private InputAction jumpAction;

    private bool isOnGround = true;

    private Animator playerAnim;

    public AudioClip jumpSfx;
    public AudioClip deathSfx;
    public AudioSource playerAudio;

    public ParticleSystem dirt;
    public ParticleSystem explosion;

    private bool isImmortal = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
        isGameOver = false;
        playerAnim.SetFloat("Speed_f", 1.0f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (jumpAction.triggered && isOnGround && !isGameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetFloat("Speed_f", 1.0f);
            playerAnim.SetTrigger("Jump_trig");
            
            playerAudio.PlayOneShot(jumpSfx);
            dirt.Stop();
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirt.Play();
            
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            GameOver();
        }
    }

    public void GameOver() 
    {
        if (isImmortal)
        {
            Debug.Log("Immortal active - no death.");
            return;
        }

        Debug.Log("Game Over");
        isGameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAudio.Stop();
        playerAudio.PlayOneShot(deathSfx);
        dirt.Stop();
        explosion.Play();
    }

   

    void OnTriggerEnter(Collider collision) 
    {
        if (collision.CompareTag("Enegy"))
        {
            FindAnyObjectByType<EnegyController>().AddEnergy(20f);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Immortal"))
        {
            FindAnyObjectByType<Immortal>().ActivateImmortal();
            Destroy(collision.gameObject);
        }
    }

    public void SetImmortal(bool value)
    {
        isImmortal = value;
    }

    public bool IsImmortal()
    {
        return isImmortal;
    }
}
