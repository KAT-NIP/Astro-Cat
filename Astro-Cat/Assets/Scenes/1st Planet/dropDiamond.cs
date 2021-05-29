using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDiamond : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    bool mouseClick = false;
    int clickCount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                text.text = "보석은 잘 모아두면 분명 쓸모가 있을 것이다.\n이 은하계를 탈출하고 싶다면 보석을 꼭 기억해!";
                clickCount++;
            }
            else
            {
                talkPanel.SetActive(false);
            }
         
        }

        if (mouseClick)
        {

        }
    }
}
