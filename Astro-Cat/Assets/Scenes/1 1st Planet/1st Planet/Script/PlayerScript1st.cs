using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript1st : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;

    int clickCount;

    // Start is called before the first frame update
    void Start()
    {
        clickCount = 0;
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
                text.text = "이제 너가 이 행성에서 처음 도착했던 곳으로 다시 돌아가.\n새로운 모험이 널 기다리고 있을테니!";
                talkPanel.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("Stepped!");
            SceneManager.LoadScene("Wormhole");
        }
    }
}
