﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text ItemText;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {

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

                    speed += 10;
                    item.gameObject.SetActive(false);
                    break;

                case Item.Type.minusVelocity:
                    Debug.Log("minusVelocity");

                    speed -= 10;
                    item.gameObject.SetActive(false);
                    break;
            }

        }

    }

    private void HideClockIcon()
    {
        SandClock.SetActive(false);
        ItemText.gameObject.SetActive(false);
    }
}
