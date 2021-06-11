using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public static int timeValue = 0; // 시간 아이템 먹을 시 시간 변화

    public Text[] timeText;
    public Text gameOverText;
    float time = 120;
    int min, sec;
    bool musicPlayed = false;
    //int min = 0;
    // Start is called before the first frame update
    public AudioSource gameOverAudioSource;

    void Start()
    {
        //제한 시간 2
        timeText[0].text = "02";
        timeText[1].text = "00";

    }

    // Update is called once per frame
    void Update()
    { 
        time -= Time.deltaTime - timeValue;
        timeValue = 0;
        //Debug.Log(time);
        //timeValue = 0;
        min = (int)time / 60;
        sec = ((int)time - min * 60) % 60;
        //int sec = (int)(time - (time/60 * 60) % 60);ß
        //Debug.Log("min" + min);
        //Debug.Log("sec" + sec);

        if (min <= 0 && sec <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
            if (!musicPlayed)
            {
                gameOverText.gameObject.SetActive(true);
                gameOverAudioSource.Play();
                musicPlayed = true;
                Invoke("restartGame", 5f);
            }
            
        }

        else {
            if (sec >= 60)
            {
                min += 1;
                sec -= 60;
            }
            else
            {
                timeText[0].text = min.ToString();
                timeText[1].text = sec.ToString();
            }
        }




        //if (min == 0 && sec == 0)
        //{
        //    timeText[0].text = "02";
        //    //min += 1;
        //}
        //else
        //{
        //    timeText[0].text = "0" + (1 - min).ToString();
        //}


        //if (60 - sec == 60)
        //{
        //    if (1 - min == 0)
        //    {
        //        timeText[0].text = "01";
        //    }
        //    timeText[1].text = "00";
        //}

        //else if(60 - sec < 10)
        //{
        //    timeText[1].text = "0" + (60 - sec).ToString();
        //}

        //else
        //{
        //    timeText[1].text = (60 - sec).ToString();
        //}

        //if (1 - min == 0 && 60 - sec == 0)
        //{
        //    //Debug.Log((1 - min) + (60 - sec));
        //    gameOverText.enabled = true;
        //    Invoke("restartGame", 5f);

        //}
    }

    void restartGame()
    {
        SceneManager.LoadScene("Maze");
    }
}