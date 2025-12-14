using UnityEngine;
using UnityEngine.TextCore.Text;

public class dragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera camera;
    public GameObject piece;
    public GameObject collisionGrid;
    private bool mouseDown = false;
    private BoxCollider2D collider;

    private void Awake()
    {
        camera = Camera.main;
        collider = GetComponent<BoxCollider2D>();
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
        mouseDown = true;
    }

    private void OnMouseDrag()
    {
        transform.position = getMousePos() + dragOffset;
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        Debug.Log("released");
        Debug.Log(collider.gameObject.CompareTag("collisionGrid"));


        if (collider.gameObject.CompareTag("collisionGrid") && !mouseDown)
        {
            piece.transform.position = collisionGrid.transform.position;
            Debug.Log("should be snapping");

        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log(other.gameObject.CompareTag("collisionGrid"));
    //    Debug.Log("colliding");


    //}


}
