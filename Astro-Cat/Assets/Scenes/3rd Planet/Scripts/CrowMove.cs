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
    //private void Awake()
    //{
    //    crow.transform.position
    //}

    Vector3 tempPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        //nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        tempPos = target.transform.position;
        //if (target.transform.rotation == Quaternion.Euler(new Vector3(0, 90, 0)))
        //{
        //    tempPos.x = tempPos.x - 10;
        //}

        //else if(target.transform.rotation == Quaternion.Euler(new Vector3(0, -90, 0)))
        //{
        //    tempPos.x = tempPos.x + 10;
        //}

        //else if(target.transform.rotation == Quaternion.Euler(new Vector3(0, -180, 0)))
        //{
        //    tempPos.z = tempPos.z + 10;
        //}

        //else if(target.transform.rotation.y == 0)
        //{
        //    tempPos.z = tempPos.z - 10;
        //}
        //tempPos.z = target.transform.position.z - 10;
        tempPos.y = crow.transform.position.y;
        crow.transform.position = tempPos;
        crow.transform.rotation = target.transform.rotation;
    }
}
