using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivedSpawner : MonoBehaviour
{
    public GameObject GhostSpawner1;
    public GameObject GhostSpawner2;
    public GameObject GhostSpawner3;

    void Update()
    {
        if(9<=transform.position.z)
        {
            GhostSpawner1.SetActive(true);
            GhostSpawner2.SetActive(false);
            GhostSpawner3.SetActive(false);
        }

        else if (-14 <= transform.position.z)
        {
            GhostSpawner1.SetActive(false);
            GhostSpawner2.SetActive(true);
            GhostSpawner3.SetActive(false);
        }

        else if (transform.position.z<=-14)
        {
            GhostSpawner1.SetActive(false);
            GhostSpawner2.SetActive(false);
            GhostSpawner3.SetActive(true);
        }
    }
}
