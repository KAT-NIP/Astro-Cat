using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    public PlayerMovement1st player;
    public GameObject dragon;

    // Start is called before the first frame update
    void Start()
    {
        dragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
