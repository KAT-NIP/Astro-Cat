﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingCat2nd : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;

    bool isJump = false;
    bool mouseClick = false;
    int clickCount = 0;
    int npc_clickCount = 0; // npc 말풍선 클릭 인식
    int devil_clickCount = 0; // Devil 말풍선 클릭 인식

    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;

    public GameObject talkPanel;
    private Text talkObjectText;
    public GameObject nametag;
    private Text npcName;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        talkObjectText = GameObject.Find("talkPanel/Text").GetComponent<Text>();
        npcName = GameObject.Find("talkPanel/nameTag/npcName").GetComponent<Text>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0)
            {
                nametag.SetActive(false);
                talkObjectText.text = "(누군가의 목소리가 들린다. 주민을 마우스로 클릭해 말을 걸어보자.)";
                clickCount++;
            }


            else if(clickCount == 1)
            {
                talkPanel.SetActive(false);
                mouseClick = true;
                clickCount++;
            }

            else if(clickCount == 2 && npc_clickCount == 1)
            {
                SceneManager.LoadScene("Ghost Hunter Game");
            }

            else if(clickCount == 2 && (devil_clickCount % 2 == 1))
            {
                talkPanel.SetActive(false);
                mouseClick = true;
                devil_clickCount++;
            }

            // 마우스로 클릭해서 인식 후 대화
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if (npc_clickCount == 0)
                {
                    if (hit.transform.gameObject.tag == "Devil")
                    {
                        Debug.Log("Devil");
                        GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                        nametag.SetActive(true);
                        npcName.text = "악마만두";
                        talkObjectText.text = "콰아아아악 꺼져";
                        devil_clickCount++;
                        Debug.Log(devil_clickCount);
                        
                    }

                    else if (hit.transform.gameObject.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                        nametag.SetActive(true);
                        npcName.text = "천사만두";
                        talkObjectText.text = "당신만이 저주받은 행성을 구할 수 있어요. 마법사를 부디 무찔러 주세요!";
                        npc_clickCount++;
                    }

                    //mouseClick = false;
                }



            }  


            Debug.Log("npc_clickCount = " + npc_clickCount);


        }

        if (mouseClick)
        {
            GetInput();
            Move();
            Turn();
            Jump();
        }

        if (transform.position.y <= -3f) {
            transform.position = new Vector3(9f, 1f, -15.1f);
        }



    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        jDown = Input.GetButton("Jump");
    }

    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetTrigger("doJump");
            isJump = true;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

            isJump = false;

        }
    }
}
