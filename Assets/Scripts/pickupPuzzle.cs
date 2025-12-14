using UnityEngine;


public class pickupPuzzle : MonoBehaviour
{

    public GameObject puzzlePiece;    //what number grid this puzzle piece is 
    public GameObject dropOffBox;     //links drop off box object to access its script
    dropOffPuzzle dropOffScript;     //links puzzle drop script


    
    void Start()
    {
        dropOffScript = dropOffBox.GetComponent<dropOffPuzzle>();       //links puzzle drop script


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))    //if player hits puzzle piece
        {
            puzzlePiece.SetActive(false);                       //deactivate
            dropOffScript.pieceCounter += 1;                    //itterate counter in dropoff script

        }
    }
}
