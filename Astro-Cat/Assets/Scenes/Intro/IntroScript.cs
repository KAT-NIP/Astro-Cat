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

    public GameObject ScriptText;
    public GameObject TitleText;
    public Text DiaryText;
    
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
                DiaryText.text = "어느 날 늘어지게 낮잠을 자고 있는 날이었어요.";
                break;
            case 1:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                DiaryText.text = "정말정말 평범한 날이었어요.";
                ScriptText.SetActive(false);
                break;
            case 2:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                DiaryText.text = "평소처럼 좋아하는 상자에 들어가있으려고 하는데,";
                break;
            case 3:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                DiaryText.text = "세상이 어두워지는 기분이 들더니";
                break;
            case 4:
                myImage.GetComponent<Image>().sprite = sprites[clickCount];
                DiaryText.text = "어쩌다 갑자기 .... ";
                break;
            case 5:
                myImage.enabled = false;
                DiaryText.text = "  ";
                TitleText.SetActive(true);
                break;
            case 6:
                SceneManager.LoadScene("Wormhole(IntroTo1st)");
                break;
            default:
                break;
        }
    }

}
