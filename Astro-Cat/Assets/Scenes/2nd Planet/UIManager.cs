using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
    public Text Ghost1Text;
    public Text Ghost2Text;
    public Text Ghost3Text;
    public Text bulletText;

    private int Ghost1Cnt;
    private int Ghost2Cnt;
    private int Ghost3Cnt;
    private int bulletCnt;

    public LivingEntity player;
    // Update is called once per frame

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<LivingEntity>();
    }
    void Update()
    {
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

        
    }

    public void UpdateAmmoText(int magAmmo)
    {
        bulletText.text = "x " + magAmmo;
    }
}
