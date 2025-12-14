using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private float horizontalInput;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float dashForce = 10f;
    bool isJumping = false;
    bool isDashing = false;
    public Transform respawnPoint;
    private AudioSource source;
    public AudioClip jumpSound;
   // public GameObject character;


    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
            source.PlayOneShot(jumpSound, 1f);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping && !isDashing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, dashForce);
            isDashing = true;
            source.PlayOneShot(jumpSound, 1f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed, rb.linearVelocity.y);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//when touching platform, logs as on ground
    {
        isJumping = false;
        isDashing = false;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = respawnPoint.transform.position;
        }
    }
}
