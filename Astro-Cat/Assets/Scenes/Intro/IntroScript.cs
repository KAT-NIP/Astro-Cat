using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    Sprite[] sprites;
    //public GameObject[] imageObj;
    public Image myImage;
    int clickCount;

    // Start is called before the first frame update
    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("images");

        clickCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            clickCount++;
        }
        switch (clickCount)
        {
            case 0:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                break;
            case 1:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                break;
            case 2:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                break;
            case 3:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                break;
            case 4:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                break;
            case 5:
                SceneManager.LoadScene("Wormhole(1stTo2nd)");
                break;
            default:
                break;
        }
    }

}
