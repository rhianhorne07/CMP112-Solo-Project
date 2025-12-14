using UnityEngine;
using UnityEngine.SceneManagement;

public class winDetection : MonoBehaviour
{
    public int piecesCorrect;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (piecesCorrect==9)                       //if all 9 puzzles correct
        {
            SceneManager.LoadScene("winScreen");     //open win screen
        }
    }
}
