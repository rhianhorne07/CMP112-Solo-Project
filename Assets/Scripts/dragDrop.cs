using UnityEngine;
using UnityEngine.TextCore.Text;

public class dragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera camera;
    public GameObject piece;
    public GameObject collisionGrid;
    public GameObject winDetectionObj;
    winDetection winDetectionScript;

    private AudioSource source;
    public AudioClip pickupSound;
    public AudioClip dropSound;


    private void Awake()
    {
        camera = Camera.main;

    }

    private void Start()
    {
        winDetectionScript = winDetectionObj.GetComponent<winDetection>();
        source = GetComponent<AudioSource>();  
    }
    private Vector3 getMousePos()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - getMousePos();
        source.PlayOneShot(pickupSound, 1f);

    }

    private void OnMouseDrag()
    {
        transform.position = getMousePos() + dragOffset;

    }

    private void OnMouseUp()
    {
        source.PlayOneShot(dropSound, 1f);

        if (piece.transform.position.x < collisionGrid.transform.position.x + 0.3f &&     //if draggable piece is close enough to grid, snap to position
            piece.transform.position.x > collisionGrid.transform.position.x - 0.3f &&
            piece.transform.position.y < collisionGrid.transform.position.y + 0.3f &&
            piece.transform.position.y > collisionGrid.transform.position.y - 0.3f)
        {
            piece.transform.position = collisionGrid.transform.position;

            winDetectionScript.piecesCorrect += 1;
        }

    }



}
