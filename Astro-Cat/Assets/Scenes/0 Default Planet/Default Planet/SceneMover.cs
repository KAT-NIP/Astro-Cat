using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMover : MonoBehaviour

{
    public Camera firstPersonCamera;
    public Camera WormholeCamera;

    //public Image Panel;
    //float time = 0f;
    //float F_time = 1f;

    //public void Fade()
    //{
    //    StartCoroutine(FadeFlow());
    //}
    //IEnumerator FadeFlow()
    //{
    //    Panel.gameObject.SetActive(true);
    //    Color alpha = Panel.color;
    //    while (alpha.a < 1f)
    //    {
    //        time += Time.deltaTime / F_time;
    //        alpha.a = Mathf.Lerp(0, 1, time);
    //        Panel.color = alpha;
    //        yield return null;
    //    }
    //    yield return null;
    //}

    void Update()

    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player.transform.position.y <= -3f)

        {
            //SceneManager.LoadScene("Wormhole");
            showWormHole();
            Invoke("sceneMove", 2.8f);
            
            //Fade();
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
        //Fade();
    }


}
