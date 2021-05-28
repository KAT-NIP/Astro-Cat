using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCat : MonoBehaviour
{ 
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;

    bool isJump = false;
    bool mouseClick = false;

    Vector3 moveVec;

    Rigidbody rigid;
    Animator anim;

    public GameObject talkPanel;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Win.SetActive(false);
            //마우스 클릭 시 대화창 사라짐
            talkPanel.SetActive(false);
            mouseClick = true;
        }

        if (mouseClick)
        {
            GetInput();
            Move();
            Turn();
            Jump();
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
        if(collision.gameObject.tag == "Floor")
        {

            isJump = false;

        }
    }
}
