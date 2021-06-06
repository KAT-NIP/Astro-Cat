using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    public Text Ghost1Text;
    public Text Ghost2Text;
    public Text Ghost3Text;

    private int Ghost1Cnt;
    private int Ghost2Cnt;
    private int Ghost3Cnt;

    // Update is called once per frame
    void Update()
    {
        GameObject[] ghost1 = GameObject.FindGameObjectsWithTag("Ghost1");
        GameObject[] ghost2 = GameObject.FindGameObjectsWithTag("Ghost2");
        GameObject[] ghost3 = GameObject.FindGameObjectsWithTag("Ghost3");

        Ghost1Cnt = ghost1.Length;
        Ghost2Cnt = ghost2.Length;
        Ghost3Cnt = ghost3.Length;

        Ghost1Text.text = "x " + Ghost1Cnt;
        Ghost2Text.text = "x " + Ghost2Cnt;
        Ghost3Text.text = "x " + Ghost3Cnt;
    }
}
