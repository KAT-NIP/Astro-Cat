using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1Spawn : MonoBehaviour
{
    public GameObject Ghost1Prefab;

    public float spawnRateMin = 7f;
    public float spawnRateMax = 7f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        //target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        // 유령 생성
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject Ghost1 = Instantiate(Ghost1Prefab, transform.position, transform.rotation);

            //Ghost1.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }
}
