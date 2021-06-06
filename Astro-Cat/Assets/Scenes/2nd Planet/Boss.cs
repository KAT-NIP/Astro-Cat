﻿using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : LivingEntity
{
    public enum CurrentState { idle, attack, dead }; // 보스 상태
    public CurrentState curState = CurrentState.idle;

    private Transform playerTransform; // 플레이어 위치
    private Transform bossTransform; // 보스 위치
    private Animator bossAnimator;
    public Animation anim;

    private bool isDead = false; // 사망 여부

    GameObject target;

    void Start()
    {

        health = 50;
        target = GameObject.FindGameObjectWithTag("Player");

        bossTransform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        bossAnimator = this.gameObject.GetComponent<Animator>();

        // StartCoroutine(this.CheckState());
        // StartCoroutine(this.CheckStateForAction());


    }




    void Update()
    {
        // 유령이 플레이어를 따라오게

        transform.LookAt(target.transform);

        if (!isDead)
        {
            float dist = Vector3.Distance(playerTransform.position, bossTransform.position);

            if (dist <= 5) // 공격해야하는 범위 내에 들어오면 공격 상태로 변ㄱ
            {
                curState = CurrentState.attack;
                bossAnimator.SetTrigger("Melee Attack");
                Debug.Log(dist);
            }

            else
            {
                curState = CurrentState.idle;

            }
        } 


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //GameObject player = other.GetComponent<GameObject>();
            Debug.Log("플레이어에게 공격 성공");

        }

    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        // LivingEntity의 OnDamage()를 실행하여 데미지 적용
        base.OnDamage(damage, hitPoint, hitNormal);
        bossAnimator.SetTrigger("Take Damage");
    }


    // 사망 처리
    public override void Die()
    {

        bossAnimator.SetTrigger("Die");

        // LivingEntity의 Die()를 실행하여 기본 사망 처리 실행
        base.Die();

        Collider[] enemyColliders = GetComponents<Collider>();

        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        isDead = true;

        bossAnimator.SetTrigger("Die");
        //Destroy(gameObject);
    }
}