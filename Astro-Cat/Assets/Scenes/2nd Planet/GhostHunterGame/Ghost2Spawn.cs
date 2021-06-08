using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2Spawn : MonoBehaviour
{

    public GameObject Ghost2Prefab;

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
        if (!UIManager.GameClear)
        {
            timeAfterSpawn += Time.deltaTime;

            // 유령 생성
            if (timeAfterSpawn >= spawnRate)
            {
                timeAfterSpawn = 0f;

                GameObject Ghost2 = Instantiate(Ghost2Prefab, transform.position, transform.rotation);



                spawnRate = Random.Range(spawnRateMin, spawnRateMax);
            }
        }

    }
}
