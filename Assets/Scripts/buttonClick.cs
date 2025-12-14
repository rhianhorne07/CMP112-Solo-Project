using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonClick : MonoBehaviour
{


    private void OnMouseDown()   //when clicked
    {
        SceneManager.LoadScene("Platformer");   //open platformer 

    }
}
