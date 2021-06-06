using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ghost3 : LivingEntity
{
    //public float speed = 8f;
    //private Rigidbody Ghost1Rigidbody;
    NavMeshAgent nav;
    GameObject target;

    Animator anim;

    //public float damage = 20f;
    public float timeBetAttack = 5.0f;
    public float lastAttackTime;

    public GameObject firePoint;
    public GameObject VFX;
    void Start()
    {
        //Ghost1Rigidbody = GetComponent<Rigidbody>();
        //Ghost1Rigidbody.velocity = transform.forward * speed;
        health = 75;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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
        Attack();
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

    private void Attack()
    {
        if(!dead && Time.time >= lastAttackTime + timeBetAttack)
        {
            anim.SetTrigger("Attack");
            if (target != null)
            {
                lastAttackTime = Time.time;
                SpawnVFX();
            }
        }
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
        Destroy(gameObject, 1f);
    }

    private void SpawnVFX()
    {
        GameObject vfx;
        vfx = Instantiate(VFX, firePoint.transform.position, Quaternion.identity);
        vfx.transform.localRotation = firePoint.transform.rotation;

        //if (firePoint != null)
        //{
        //    vfx = Instantiate(VFX, firePoint.transform.position, Quaternion.identity);
        //    vfx.transform.localRotation = target.transform.rotation;
        //}
        //else
        //    vfx = Instantiate(VFX);
    }
}
