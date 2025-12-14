using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.TextCore.Text;

public class dragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera camera;         //to determine offset
    public GameObject piece;
    public GameObject collisionGrid;
    public GameObject winDetectionObj;          //obj to access its scripts
    winDetection winDetectionScript;                //links scripts

    private AudioSource source;
    public AudioClip pickupSound;
    public AudioClip dropSound;


    private void Awake()
    {
        camera = Camera.main;   //store camera

    }

    private void Start()
    {
        winDetectionScript = winDetectionObj.GetComponent<winDetection>(); //links scripts
        source = GetComponent<AudioSource>();  
    }
    private Vector3 getMousePos()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);   //store where in game scene mouse is
        pos.z = 0;
        return pos;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - getMousePos();      //so doesnt snap to centre when pressed
        source.PlayOneShot(pickupSound, 1f);

    }

    private void OnMouseDrag()
    {
        transform.position = getMousePos() + dragOffset;     //moves with mouse

    }

    private void OnMouseUp()
    {
        source.PlayOneShot(dropSound, 1f);

        if (piece.transform.position.x < collisionGrid.transform.position.x + 0.3f &&   //if draggable piece is close enough to grid, snap to position
            piece.transform.position.x > collisionGrid.transform.position.x - 0.3f &&
            piece.transform.position.y < collisionGrid.transform.position.y + 0.3f &&
            piece.transform.position.y > collisionGrid.transform.position.y - 0.3f)
        {
            piece.transform.position = collisionGrid.transform.position;     //snap

            winDetectionScript.piecesCorrect += 1;              //itterate win detection script
        }

    }



}
