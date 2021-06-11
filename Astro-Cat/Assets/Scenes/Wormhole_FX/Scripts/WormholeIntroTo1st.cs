using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormholeIntroTo1st : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -40)
        {
            SceneManager.LoadScene("Default Planet");
        }
    }
}
