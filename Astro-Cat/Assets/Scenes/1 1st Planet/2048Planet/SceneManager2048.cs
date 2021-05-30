using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager2048 : MonoBehaviour
{
    public SquareManager squareManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(squareManager.isGameOver)
        {
            Invoke("SceneMove", 2.0f);
        }
    }

    public void SceneMove()
    {
        SceneManager.LoadScene("1st Planet after game");
    }
}
