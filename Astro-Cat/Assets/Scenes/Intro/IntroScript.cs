using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public GameObject image;
    Sprite[] sprites;
    public GameObject[] imageObj;
    public Image myImage;
    int index;

    public float slide = 2f;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("images");

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time == slide && index < 5)
        {
            image.GetComponent<Image>().sprite = sprites[index];
            index++;
            time = 0f;
        }

        if (index == 5)
        {
            SceneManager.LoadScene("Wormhole(1stTo2nd)");
        }
    }
}
