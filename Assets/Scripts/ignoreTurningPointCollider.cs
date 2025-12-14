using UnityEngine;

public class ignoreTurningPointCollider : MonoBehaviour
{

    BoxCollider2D spawnPointCollider1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPointCollider1 = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spawnPointCollider1.isTrigger = true;

        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            spawnPointCollider1.isTrigger = false;

        }
    }
}
