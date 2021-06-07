using System.Collections;
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
    public Text talkObjectText;
    public GameObject nametag;
    public Text npcName;
    private AudioSource playerAudio;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }



    void Update()
    {
        Debug.Log(mouseClick);
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0) // 맨 처음 말풍선
            {
                nametag.SetActive(false);
                talkObjectText.text = "(누군가의 목소리가 들린다. 주민을 마우스로 클릭해 말을 걸어보자.)";
                clickCount++;
                mouseClick = true;
            }


            else if (clickCount == 1)
            {
                talkPanel.SetActive(false);
                mouseClick = true;
                clickCount++;
            }

            else if (npc_clickCount == 1) // 천사만두 npc
            {
                talkObjectText.text = "마법사와 그의 생성물인 유령들이 저희 행성을 이렇게 망쳐놓았어요.";
                npc_clickCount++;
            }

            else if (npc_clickCount == 2)
            {
                talkObjectText.text = "당신에게 총을 드릴게요! 이 총이라면 마법사와 유령을 모두 소멸시킬 수 있을거에요.";
                playerAudio.Play();
                GameObject.Find("Hand_r_equipment").transform.Find("Gun").gameObject.SetActive(true);
                npc_clickCount++;
            }

            else if (npc_clickCount == 3)
            {
                talkObjectText.text = "마우스 왼쪽 버튼을 클릭하면 총을 발사할 수 있어요. 유령과 닿으면 체력이 줄어드니 조심하세요.";
                npc_clickCount++;
            }

            else if (npc_clickCount == 4)
            {
                talkObjectText.text = "아, 마법사와 해골 유령은 모험가님을 공격할 수 있으니 주의하세요.";
                npc_clickCount++;
            }

            else if (npc_clickCount == 5)
            {
                talkObjectText.text = "당신만이 저주받은 행성을 구할 수 있어요. 마법사를 꼭 무찔러주세요.";
                npc_clickCount++;
            }


            else if (npc_clickCount == 6)
            {
                SceneManager.LoadScene("Ghost Hunter Game copy copy");
            }

            else if (clickCount == 2 && (devil_clickCount % 2 == 1)) // 악마만두
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

                if (hit.transform.gameObject.tag == "Devil") // 악마만두 클릭 시
                {
                    Debug.Log("Devil");
                    //GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                    talkPanel.SetActive(true);
                    nametag.SetActive(true);
                    npcName.text = "악마만두";
                    talkObjectText.text = "콰아아아악 꺼져";
                    devil_clickCount++;
                    Debug.Log(devil_clickCount);
                    mouseClick = false;

                }

                else if (hit.transform.gameObject.tag == "Angel")
                {
                    Debug.Log("Angel");
                    //GameObject.Find("Canvas").transform.Find("talkPanel").gameObject.SetActive(true);
                    talkPanel.SetActive(true);
                    nametag.SetActive(true);
                    npcName.text = "천사만두";

                    if (npc_clickCount == 0) // 천사만두 클릭 시
                    {
                        talkObjectText.text = "용감한 모험가님.. 저희를 구하러 와주셨군요!";
                        npc_clickCount++;
                    }
                    mouseClick = false;

                }

                
            }



        }


        Debug.Log("npc_clickCount = " + npc_clickCount);




        if (mouseClick)
        {
            GetInput();
            Move();
            Turn();
            Jump();
        }

        if (transform.position.y <= -3f) // 떨어지면 Waypoint로 복귀
        {
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