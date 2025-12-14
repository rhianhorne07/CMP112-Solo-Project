using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject character;
    public Transform respawnPoint;
    private AudioSource source;
    public AudioClip dieSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            source.PlayOneShot(dieSound, 1f);
            character.transform.position = respawnPoint.position;
        }
    }
}
