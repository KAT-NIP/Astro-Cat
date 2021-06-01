using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetDiamondAndMove : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    public GameObject diamond;
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
                talkPanel.SetActive(false);
                clickCount++;
                //보석 나타나게
            }

            else if(clickCount == 1)
            {
                talkPanel.SetActive(true);
                text.text = "안녕히 가세요!!\n다음 행성은 까마귀를 조심하세요!";
                clickCount++;
            }

            else if(clickCount == 2)
            {
                SceneManager.LoadScene("Wormhole");
            }
        }
    }
}
