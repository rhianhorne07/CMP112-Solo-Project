using UnityEngine;

public class dropOffPuzzle : MonoBehaviour
{
    [SerializeField] public int pieceCounter;
    [SerializeField] public int test;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && pieceCounter == 9)
        {
            test = 100;
        }
    }
}
