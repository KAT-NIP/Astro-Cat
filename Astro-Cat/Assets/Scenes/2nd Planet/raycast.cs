using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{

    bool mouseClick = false;
    int clickCount = 0;

    public GameObject talkPanel;
    private Text talkObjectText;
    public GameObject nametag;
    private Text npcName;

    private void Awake()
    {
        talkObjectText = GameObject.Find("talkPanel/Text").GetComponent<Text>();
        npcName = GameObject.Find("talkPanel/nameTag/npcName").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);

                if (hit.transform.gameObject.tag == "Devil")
                {
                    Debug.Log("what");
                    GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                    nametag.SetActive(true);
                    npcName.text = "중독된 주민";
                    talkObjectText.text = "콰아아아악 꺼져";

                }
            }

        }
    }
}
