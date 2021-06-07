using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowMove : MonoBehaviour
{
    public GameObject crow;
    //public NavMeshAgent nav;
    GameObject target;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos = target.transform.position;
        tempPos.z = target.transform.position.z - 10;
        tempPos.y = crow.transform.position.y;
        crow.transform.position = tempPos;
        crow.transform.rotation = target.transform.rotation;
    }
}
