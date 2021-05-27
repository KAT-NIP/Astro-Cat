using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCat : MonoBehaviour
{
    public float speed = 2.0f;
    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }
}
