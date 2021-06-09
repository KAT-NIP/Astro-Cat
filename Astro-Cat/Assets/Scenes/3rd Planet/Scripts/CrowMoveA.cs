using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMoveA : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirection();
    }

    void CheckDirection()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            anim.SetTrigger("TurnLeft");
        }
        else if(Input.GetAxis("Horizontal") > 0)
        {
            anim.SetTrigger("TurnRight");
        }
    }
}
