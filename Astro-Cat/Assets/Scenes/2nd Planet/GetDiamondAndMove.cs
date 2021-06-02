using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetDiamondAndMove : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    public GameObject diamond;

    public AudioSource effectSound;

    bool touchPlayer = false;
    bool mouseClick = false;
    int clickCount = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0 && !mouseClick)
            {
                talkPanel.SetActive(false);

                mouseClick = true;

                effectSound.Play();
                //effectSound.loop = false;
                diamond.SetActive(true);
                //effectSound.Pause();
            }

            else if(clickCount == 2 && touchPlayer == true)
            {
                SceneManager.LoadScene("Wormhole(2ndTo3rd)");
            }
        }

        if (clickCount == 0 && mouseClick)
        {
            Debug.Log("transform");
            diamond.transform.position += new Vector3(0, -Time.deltaTime/2, 0);
            if (diamond.transform.position.y < 3.5)
            {
                Debug.Log("hi\n");
                diamond.SetActive(false);
                effectSound.Play();
                touchPlayer = true;
                clickCount++;
            }

        }

        if (clickCount == 1 && touchPlayer == true)
        {
            talkPanel.SetActive(true);
            text.text = "안녕히 가세요!!\n다음 행성은 까마귀를 조심하세요!";
            clickCount++;
        }
    }

    
}
