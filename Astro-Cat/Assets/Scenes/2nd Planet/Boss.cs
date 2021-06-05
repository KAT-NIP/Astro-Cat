using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : LivingEntity
{
    
    GameObject target;

    void Start()
    {

        health = 25;
        target = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        // 유령이 플레이어를 따라오게

        //nav.SetDestination(target.transform.position);
        transform.LookAt(target.transform);

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

        Collider[] enemyColliders = GetComponents<Collider>();

        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        Destroy(gameObject);
    }
}