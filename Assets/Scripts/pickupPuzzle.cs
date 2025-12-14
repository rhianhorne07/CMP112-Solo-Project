using UnityEngine;


public class pickupPuzzle : MonoBehaviour
{

    public GameObject puzzlePiece;
    public GameObject dropOffBox;
    dropOffPuzzle dropOffScript;

    private AudioSource source;
    public AudioClip pickupSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dropOffScript = dropOffBox.GetComponent<dropOffPuzzle>();
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(pickupSound, 1f);
            puzzlePiece.SetActive(false);
            dropOffScript.pieceCounter += 1;

        }
    }
}
