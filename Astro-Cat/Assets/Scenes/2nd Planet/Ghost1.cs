using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1 : LivingEntity
{

    NavMeshAgent nav;
    GameObject target;

    Animator anim;

    void Start()
    {

        health = 25;
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");

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

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // LivingEntity의 OnDamage()를 실행하여 데미지 적용
        base.OnDamage(damage, hitPoint, hitNormal);
    }

    // 사망 처리
    public override void Die()
    {
        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();
        anim.SetTrigger("Die");
        Collider[] enemyColliders = GetComponents<Collider>();

        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        UIManager.deadLife++;
        Destroy(gameObject, 1f);
    }
}
