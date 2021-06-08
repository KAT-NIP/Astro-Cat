using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int deadLife; // 죽은 생명 수

    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();

            }
            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수
    public GameObject GamePanel;
    public Text Ghost1Text;
    public Text Ghost2Text;
    public Text Ghost3Text;
    public Text bulletText;

    private int Ghost1Cnt;
    private int Ghost2Cnt;
    private int Ghost3Cnt;
    private int bulletCnt;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    public LivingEntity player;
    public Boss boss;
    public static bool GameClear = false; // 게임 클리어 시

    public GameObject talkPanel;
    // Update is called once per frame

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>();
        
    }
    void Update()
    {


        // 게임 클리어 시 행성 이동
        if (GameClear && Input.GetMouseButtonDown(0))
        {

            Debug.Log("씬 변경");
            SceneManager.LoadScene("Default Planet");

        }

        if (GameClear)
        {
            //GameObject.FindGameObjectWithTag("Ghost1").SetActive(false);
            //GameObject.FindGameObjectWithTag("Ghost2").SetActive(false);
            //GameObject.FindGameObjectWithTag("Ghost3").SetActive(false);
        }

        if (!player.dead)
        {
            Gun gun = GameObject.Find("Gun").GetComponent<Gun>();
            bulletCnt = gun.magAmmo;

            GameObject[] ghost1 = GameObject.FindGameObjectsWithTag("Ghost1");
            GameObject[] ghost2 = GameObject.FindGameObjectsWithTag("Ghost2");
            GameObject[] ghost3 = GameObject.FindGameObjectsWithTag("Ghost3");

            Ghost1Cnt = ghost1.Length;
            Ghost2Cnt = ghost2.Length;
            Ghost3Cnt = ghost3.Length;

            Ghost1Text.text = "x " + Ghost1Cnt;
            Ghost2Text.text = "x " + Ghost2Cnt;
            Ghost3Text.text = "x " + Ghost3Cnt;

            bulletText.text = "x " + bulletCnt;
        }


        if (UIManager.deadLife >= 5)
        {
            GameObject.Find("BossAppear").transform.Find("Boss").gameObject.SetActive(true);
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }


        if (boss.dead)
        {
            GameClear = true;
            GamePanel.SetActive(false);
            talkPanel.SetActive(true);

            //GameObject.Find("Ghost1(Clone)").SetActive(false);
            //GameObject.Find("Ghost2(Clone)").SetActive(false);
            //GameObject.Find("Ghost3(Clone)").SetActive(false);
            //GameObject.FindGameObjectWithTag("Ghost1").SetActive(false);
            //GameObject.FindGameObjectWithTag("Ghost2").SetActive(false);
            //GameObject.FindGameObjectWithTag("Ghost3").SetActive(false);

            //GameObject.FindGameObjectWithTag("Bullet").SetActive(false);
            GameObject[] ghost1 = GameObject.FindGameObjectsWithTag("Ghost1");
            GameObject[] ghost2 = GameObject.FindGameObjectsWithTag("Ghost2");
            GameObject[] ghost3 = GameObject.FindGameObjectsWithTag("Ghost3");

            for(int i = 0; i < ghost1.Length; i++)
            {
                Destroy(ghost1[i]);
            }
            for (int i = 0; i < ghost2.Length; i++)
            {
                Destroy(ghost2[i]);
            }
            for (int i = 0; i < ghost3.Length; i++)
            {
                Destroy(ghost3[i]);
            }
        }
    }

    public void UpdateLifeImage()
    {
        Debug.Log("UImanger"+player.health);
        if (player.health == 80)
        {
            heart1.gameObject.SetActive(false);
        }
        else if (player.health == 60)
        {
            heart2.gameObject.SetActive(false);
        }
        else if (player.health == 40)
        {
            heart3.gameObject.SetActive(false);
        }
        else if (player.health == 20)
        {
            heart4.gameObject.SetActive(false);
        }
        else if (player.health == 0) 
        {
            heart5.gameObject.SetActive(false);
        }
    }

    public void UpdateAmmoText(int magAmmo)
    {
        bulletText.text = "x " + magAmmo;
    }
}
