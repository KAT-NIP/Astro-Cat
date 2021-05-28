using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour

{

    void Update()

    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.transform.position.y <= -3f)

        {

            SceneManager.LoadScene("1st Planet");

        }

    }

}
