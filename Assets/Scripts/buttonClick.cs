using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour
{


    private void OnMouseDown()
    {
        SceneManager.LoadScene("Platformer");

    }
}
