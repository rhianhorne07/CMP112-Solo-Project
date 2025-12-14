using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject character;
    public Transform respawnPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            character.transform.position = respawnPoint.position;
        }
    }
}
