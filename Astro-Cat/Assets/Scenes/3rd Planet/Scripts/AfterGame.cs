using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AfterGame : MonoBehaviour
{
    public GameObject talkPanel;
    private Text talkText;
    public Text name;

    public GameObject[] gems;
    bool gemActive = false;
    bool gemSoundPlayed = false;

    public GameObject key;
    bool keyStart = false;

    public GameObject hamsterKing;

    public AudioSource crowSound;
    public AudioSource gemSound;

    int clickCount;
    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;
        talkText = GameObject.Find("talkPanel/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                Debug.Log(clickCount);
                name.text = "크로우";
                talkText.text = "까악\n까악";
                crowSound.Play();
                clickCount++;
            }

            else if(clickCount == 1)
            {
                Debug.Log(clickCount);

                name.text = "햄토리 왕";
                talkText.text = "뭐야 진짜야..? 크로우가 지다니..\n내가 한 약속은 지켜야겠지..";
                clickCount++;
            }

            else if(clickCount == 2)
            {
                Debug.Log(clickCount);

                talkText.text = "모은 보석을 주면 열쇠로 교환해줄게.\n이 열쇠로 여기를 나가서 주인이 있는 곳으로 돌아가.";
                clickCount++;
            }

            else if (clickCount == 3)
            {
                Debug.Log(clickCount);

                talkPanel.SetActive(false);
                gemActive = true;

            }

            else if(clickCount == 4)
            {
                //웜홀로 씬 전환
                SceneManager.LoadScene("Wormhole(3rdToEnd)");
            }
        }


        if(gemActive)
        {
            if (!gemSoundPlayed)
            {
                gemSound.Play();
                gemSoundPlayed = true;
            }

            gems[0].SetActive(true);
            gems[1].SetActive(true);
            gems[2].SetActive(true);

            gems[0].transform.position += new Vector3(-Time.deltaTime, 0, 0);
            gems[1].transform.position += new Vector3(-Time.deltaTime, 0, 0);
            gems[2].transform.position += new Vector3(-Time.deltaTime, 0, 0);

            if(gems[0].transform.position.x <= -1.5 && gems[1].transform.position.x <= -1.5 && gems[2].transform.position.x <= -1.5)
            {
                gemActive = false;
                keyStart = true;
            }
        }

        if (!gemActive && keyStart)
        {
            gems[0].SetActive(false);
            gems[1].SetActive(false);
            gems[2].SetActive(false);

            key.SetActive(true);
            if (gemSoundPlayed)
            {
                gemSound.Play();
                gemSoundPlayed = false;
            }

            key.transform.position += new Vector3(Time.deltaTime, 0, 0);

            if(key.transform.position.x >= 0)
            {
                key.SetActive(false);
                talkPanel.SetActive(true);
                name.text = "냥냥이";
                talkText.text = "드디어 돌아갈 수 있게 되었구나\n얼른 주인에게 돌아가야겠어! 열쇠야 도와줘!";
                clickCount = 4;
            }

        }


    }
}
