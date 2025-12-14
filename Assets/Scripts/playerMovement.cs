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
    public AudioClip dieSound;
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
        horizontalInput = Input.GetAxis("Horizontal");   //get input
        
        
        
        if (Input.GetButtonDown("Jump") && !isJumping)     //if jump button pressed
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);   //jump
            isJumping = true;
            source.PlayOneShot(jumpSound, 1f);

        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping && !isDashing)    //if already jumping and dash pressed
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, dashForce);  //dash
            isDashing = true;
            source.PlayOneShot(jumpSound, 1f);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed, rb.linearVelocity.y);    //horizontal movement

        if (horizontalInput > 0)                //flip sprite to face correct way
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

        if (collision.gameObject.CompareTag("Enemy"))                    //if player hits enemy, respawn
        {
            source.PlayOneShot(dieSound, 1f);
            transform.position = respawnPoint.transform.position;

        }
    }
}
