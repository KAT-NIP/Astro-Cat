using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour

{
    public Camera firstPersonCamera;
    public Camera WormholeCamera;

    void Update()

    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.transform.position.y <= -3f)

        {
            //SceneManager.LoadScene("Wormhole");
            showWormHole();
            Invoke("sceneMove", 2.8f);
        }

    }

    public void showWormHole()
    {
        WormholeCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    public void sceneMove()
    {
        SceneManager.LoadScene("1st Planet");
    }


}
