using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1st : MonoBehaviour
{
    public float speed;

    float hAxis;
    float vAxis;

    public bool onFloor;

    Vector3 moveVec;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        onFloor = false;
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("Stepped!");
            onFloor = true;
            GameObject.Find("Dragon").transform.Find("DragonSD_32").gameObject.SetActive(true);
        }
    }
}
