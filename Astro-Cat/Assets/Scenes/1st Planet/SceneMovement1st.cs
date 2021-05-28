using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMovement1st : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        if (player.onFloor)
        {
            Invoke("SceneMove", 2.0f);
        }
    }

    public void SceneMove()
    {
        SceneManager.LoadScene("2048Scene");
    }
}
