using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovingCatMaze : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;

    bool isJump = false;
    bool mouseClick = false;
    int clickCount = 0;

    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;

    public GameObject SandClock;
    public GameObject Velocity;
    public Text ItemText;
    public GameObject crow;
    public GameObject newCrow;

    public Text[] timeText;

    public GameObject RawImage1;
    public GameObject RawImage2;

    public GameObject talkPanel;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickCount == 1)
        {
            talkPanel.SetActive(false);
        }

        GetInput();
        Move();
        Turn();
        Jump();


    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    private void FixedUpdate()
    {
        FreezeRotation();
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
        if (speed <= 5)
        {
            speed = 5;
        }

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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.plusTime:
                    Debug.Log("plusTime");
                    SandClock.SetActive(true);
                    ItemText.text = "+10";
                    ItemText.gameObject.SetActive(true);

                    TimeControl.timeValue = 10;
                    item.gameObject.SetActive(false);

                    Invoke("HideClockIcon", 1f);
                    break;

                case Item.Type.minusTime:
                    Debug.Log("minusTime");
                    SandClock.SetActive(true);
                    ItemText.text = "-10";
                    ItemText.gameObject.SetActive(true);

                    TimeControl.timeValue = -10;
                    item.gameObject.SetActive(false);

                    Invoke("HideClockIcon", 1f);
                    break;

                case Item.Type.plusVelocity:
                    Debug.Log("plusVelocity");
                    Velocity.SetActive(true);
                    ItemText.text = "+5";
                    ItemText.gameObject.SetActive(true);

                    speed += 5;
                    item.gameObject.SetActive(false);

                    Invoke("HideVelocityIcon", 1f);
                    break;

                case Item.Type.minusVelocity:
                    Debug.Log("minusVelocity");
                    Velocity.SetActive(true);
                    ItemText.text = "-5";
                    ItemText.gameObject.SetActive(true);

                    Invoke("HideVelocityIcon", 1f);
                    speed -= 5;
                    item.gameObject.SetActive(false);
                    break;
            }

        }

        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("finished!");
            timeText[0].gameObject.SetActive(false);
            timeText[1].gameObject.SetActive(false);
            timeText[2].gameObject.SetActive(false);
            crow.SetActive(false);
            newCrow.SetActive(true);

            RawImage1.SetActive(false);
            RawImage2.SetActive(false);

            talkPanel.SetActive(true);

            clickCount = 1;
            Debug.Log("clickCount" + clickCount);
            //SceneManager.LoadScene("Maze");
        }


    }

    private void HideClockIcon()
    {
        SandClock.SetActive(false);
        ItemText.gameObject.SetActive(false);
    }

    private void HideVelocityIcon()
    {
        Velocity.SetActive(false);
        ItemText.gameObject.SetActive(false);
    }
}
