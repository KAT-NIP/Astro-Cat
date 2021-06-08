using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour
{
    public Text[] timeText;
    public Text gameOverText;
    float time;
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
        timeText[0].text = "0" + (1 - ((int)time / 60 % 60)).ToString();
        if(60 - ((int)time % 60) == 60)
        {
            timeText[1].text = "00";
        }
        else if(60 - ((int)time % 60) < 10)
        {
            timeText[1].text = "0" + (60 - ((int)time % 60)).ToString();
        } else
        {
            timeText[1].text = (60 - ((int)time % 60)).ToString();
        }

        if(1 - ((int)time / 60 % 60) == 0 && (int)time % 60 == 0)
        {
            gameOverText.enabled = true;
            Invoke("restartGame", 5f);
            
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene("Maze");
    }
}
