using UnityEngine;

public class dragDrop : MonoBehaviour
{
    private Vector3 dragOffset;
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void OnMouseDown()
    {
        dragOffset = transform.position - getMousePos();
    }

    private void OnMouseDrag()
    {
                transform.position = getMousePos() + dragOffset;
    }

    private Vector3 getMousePos()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        return pos;
    }
}
