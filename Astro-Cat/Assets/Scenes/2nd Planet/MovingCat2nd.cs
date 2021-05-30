using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCat2nd : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;

    bool isJump = false;
    bool mouseClick = false;
    int clickCount = 0;
    int npc_clickCount = 0;

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
            }

            // 마우스 클릭 인식
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (clickCount >= 1 && Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.gameObject);
                if(npc_clickCount == 1)
                {
                    if (hit.transform.gameObject.tag == "Devil")
                    {
                        Debug.Log("Devil");
                        GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                        nametag.SetActive(true);
                        npcName.text = "악마만두";
                        talkObjectText.text = "콰아아아악 꺼져";
                       
                    }

                    else if (hit.transform.gameObject.tag == "Angel")
                    {
                        Debug.Log("Angel");
                        GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                        nametag.SetActive(true);
                        npcName.text = "천사만두";
                        talkObjectText.text = "저희 마을과 제 친구들이 모두 저주에 걸렸어요!";
                        
                    }
                }
                npc_clickCount++;
            }  


            if (npc_clickCount == 2)
            {
                talkObjectText.text = "(.. 다른 주민을 찾아보자 ..)";
            }

            if(npc_clickCount == 3)
            {
                talkPanel.SetActive(false);
                npc_clickCount = 0;
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
