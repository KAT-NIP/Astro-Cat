using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeControl1 : MonoBehaviour
{
    //public static int timeValue = 10;
    public Text[] timeText;
    public Text gameOverText;
    float time;
    //int min = 0;
    // Start is called before the first frame update
    void Start()
    {
        //제한 시간 2
        timeText[0].text = "02";
        timeText[1].text = "00";

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int min = (int)time / 60 % 60;
        int sec = (int)time % 60;
        
        Debug.Log("min = " + min);
        Debug.Log("sec = " + sec);

        if (min == 0 && sec == 0)
        {
            timeText[0].text = "02";
            //min += 1;
        }
        else
        {
            timeText[0].text = "0" + (1 - min).ToString();
        }


        if (60 - sec == 60)
        {
            if (1 - min == 0)
            {
                timeText[0].text = "01";
            }
            timeText[1].text = "00";
        }

        else if(60 - sec < 10)
        {
            timeText[1].text = "0" + (60 - sec).ToString();
        }

        else
        {
            timeText[1].text = (60 - sec).ToString();
        }

        if (1 - min == 0 && 60 - sec == 0)
        {
            Debug.Log((1 - min) + (60 - sec));
            gameOverText.enabled = true;
            Invoke("restartGame", 5f);

        }
    }

    void restartGame()
    {
        SceneManager.LoadScene("Maze");
    }
}
