using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfterGame : MonoBehaviour
{
    public GameObject talkPanel;
    private Text talkText;
    public Text name;

    public GameObject[] gems;
    bool[] gemActive;
    int gemIndex = 0;

    public GameObject hamsterKing;

    public AudioSource crowSound;

    int clickCount;
    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;
        gemActive = new bool[3];
        for(int i = 0; i<3; i++)
        {
            gemActive[i] = false;
        }
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
                if (gemActive[0]) //gems[0]참
                {
                    if (gemActive[1]) //gems[0] && gems[1] 참
                    {
                        if (gemActive[2]) //gems[0] && gems[1] && gems[2] 참
                        {
                            gems[0].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);
                            gems[1].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);
                            gems[2].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);

                            if (gems[0].transform.position.x == hamsterKing.transform.position.x)
                            {
                                gems[0].SetActive(false);
                            }

                            if (gems[1].transform.position.x == hamsterKing.transform.position.x)
                            {
                                gems[1].SetActive(false);
                            }

                            if (gems[2].transform.position.x == hamsterKing.transform.position.x)
                            {
                                gems[2].SetActive(false);
                            }
                        }

                        else //gems[2] 활성화활 차례
                        {
                            gems[2].SetActive(true);
                            gems[0].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);
                            gems[1].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);
                            gems[2].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);

                            if (gems[0].transform.position.x == hamsterKing.transform.position.x)
                            {
                                gems[0].SetActive(false);
                            }

                            if (gems[1].transform.position.x == hamsterKing.transform.position.x)
                            {
                                gems[1].SetActive(false);
                            }

                            if (gems[2].transform.position.x == hamsterKing.transform.position.x / 3)
                            {
                                gemActive[2] = true;
                            }
                        }
                    }

                    else //gems[1] 활성화할 차례
                    {
                        gems[1].SetActive(true);
                        gems[0].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);
                        gems[1].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);


                        if (gems[0].transform.position.x == hamsterKing.transform.position.x)
                        {
                            gems[0].SetActive(false);
                        }

                        if (gems[1].transform.position.x == hamsterKing.transform.position.x / 3)
                        {
                            gemActive[1] = true;
                        }
                    }

                }

                else //gems[0] 활성화할 차례
                {
                    gems[0].SetActive(true);
                    gems[0].transform.position += new Vector3(-Time.deltaTime / 2, 0, 0);

                    if (gems[0].transform.position.x == hamsterKing.transform.position.x / 3)
                    {
                        gemActive[0] = true;
                    }
                }


            }
        }

       
    }
}
