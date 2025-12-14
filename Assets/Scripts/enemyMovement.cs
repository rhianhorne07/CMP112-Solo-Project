using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float enemySpeed = -2f;
    private Vector2 startPos;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(enemySpeed, rb.linearVelocity.y);

        if (transform.position.x == startPos.x + 1f) 
        {
            enemySpeed = -enemySpeed;
        }
        else if (transform.position.x == startPos.x)
        {
            enemySpeed = -enemySpeed;
        }


    }
}
