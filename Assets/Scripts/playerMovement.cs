using UnityEngine;

public class playerMovement : MonoBehaviour
{

    private float horizontalInput;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float dashForce = 10f;
    bool isJumping = false;
    bool isDashing = false;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isJumping && !isDashing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, dashForce);
            isDashing = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * playerSpeed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)//when touching platform, logs as on ground
    {
        isJumping = false;
        isDashing = false;
    }
}
