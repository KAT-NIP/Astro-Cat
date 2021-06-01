using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript1st : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    GameObject gem; // 보석
    int clickCount = 0;
    bool getGem = false;

    void Start()
    {
        clickCount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (getGem == false && clickCount == 0)
            {
                text.text = "보석은 잘 모아두면 분명 쓸모가 있을 것이다.\n이 은하계를 탈출하고 싶다면 보석을 꼭 기억해!";
                clickCount++;
            }

            else if (getGem == false && clickCount == 1) // 보석 나타남
            {
                talkPanel.SetActive(false);
                GameObject.Find("Gem").transform.Find("Diamond").gameObject.SetActive(true);
                clickCount++;
            }

            else if (getGem == true && clickCount == 2)
            {
                talkPanel.SetActive(false);
            }

            Debug.Log(clickCount);
        }

        if (getGem == true) // 보석을 얻으면 말풍선이 바로 나타남
        {
            talkPanel.SetActive(true);
            text.text = "이제 너가 이 행성에서 처음 도착했던 곳으로 다시 돌아가.\n새로운 모험이 널 기다리고 있을테니!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (getGem == true)
        {
            if (collision.gameObject.tag == "Floor")
            {
                Debug.Log("Stepped!");
                SceneManager.LoadScene("Wormhole");
            }
        }

    }

    private void OnTriggerEnter(Collider other) // 보석 먹으면 사라짐
    {
        if (other.tag == "Gem")
        {
            getGem = true;
            gem = other.GetComponent<GameObject>();
            Destroy(other.gameObject);
        }
    }
}
