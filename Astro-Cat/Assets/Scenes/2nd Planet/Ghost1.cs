using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody Ghost1Rigidbody;

    void Start()
    {
        Ghost1Rigidbody = GetComponent<Rigidbody>();
        Ghost1Rigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.GetComponent<GameObject>();
            Debug.Log("부딪힘");

        }

    }
}
