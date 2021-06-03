using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : MonoBehaviour
{
    //public float speed = 8f;
    //private Rigidbody Ghost1Rigidbody;
    NavMeshAgent nav;
    GameObject target;


    void Start()
    {
        //Ghost1Rigidbody = GetComponent<Rigidbody>();
        //Ghost1Rigidbody.velocity = transform.forward * speed;

        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
        //Destroy(gameObject, 2f);
    }

    void Update()
    {
        // 유령이 플레이어를 따라오게
        //if (nav.destination != target.transform.position)
        //{
        nav.SetDestination(target.transform.position);
        //}
        //else
        //{
        //    nav.SetDestination(transform.position);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameObject player = other.GetComponent<GameObject>();
            Debug.Log("부딪힘");

        }

    }
}
