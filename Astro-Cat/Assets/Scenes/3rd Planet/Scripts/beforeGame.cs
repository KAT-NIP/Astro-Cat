using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class beforeGame : MonoBehaviour
{
    public GameObject crow;
    public GameObject hamster;

    public AudioSource crowSound;

    public GameObject talkPanel;
    public Text nameTagName;
    public Text text;
    private int mouseClick = 0;

    public Camera hamstoCamera;
    public GameObject hamstoFace;
    //public MeshRenderer face;
    public Material beforeFace;
    public Material afterFace;

    private void Awake()
    {
        crowSound.Play();
        set_skinned_mat("Face", 0, beforeFace);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        crow.SetActive(true);
        hamster.SetActive(true);
        //빌런 등장

        if (Input.GetMouseButtonDown(0))
        {
            if(mouseClick == 0)
            {
                nameTagName.text = "냥냥이";
                text.text = "???\n뭐야 누구세요?!";
                mouseClick++;
            }

            else if(mouseClick == 1)
            {
                nameTagName.text = "햄토리 왕";
                text.text = "나는 햄토리 왕이다. 이 은하계를 아우르고 있지.\n뒤에는 내 애완동물 크로우다.";
                mouseClick++;
            }

            else if(mouseClick == 2)
            {
                nameTagName.text = "미스터 크로우";
                text.text = "까악\n까악";
                mouseClick++;
            }

            else if(mouseClick == 3)
            {
                nameTagName.text = "냥냥이";
                text.text = "제가 주인 곁으로 돌아갈 수 있게 해주세요..\n저를 애타게 찾고 있을거에요 ㅠ.ㅠ";
                mouseClick++;
            }

            else if(mouseClick == 4)
            {
                nameTagName.text = "햄토리 왕";
                text.text = "어림도 없지! 은하계를 나가는 비밀은 나만 알고 있지만\n그걸 알고 싶으면 보석부터 모아오라구~";
                mouseClick++;
            }

            else if(mouseClick == 5)
            {
                nameTagName.text = "냥냥이";
                text.text = "보석은 두 개나 있다고요!\n얼른 돌아가게 해줘요.";
                mouseClick++;
            }

            else if(mouseClick == 6)
            {
                set_skinned_mat("Face", 1, afterFace);
                //카메라 전환(햄토리 줌인 카메라)
                hamstoCamera.enabled = true;
                nameTagName.text = "햄토리 왕";
                text.text = "두 개는 어림도 없지!! 세 개는 모아와야 하는거 아닌가?\n제한시간 안에 내 크로우와 미로 술래잡기를 해서 이기면 보석을 하나 더 주지.";
                mouseClick++;
            }

            else if(mouseClick == 7)
            {
                talkPanel.SetActive(false);
                SceneManager.LoadScene("3rd Planet Maze");
            }
        }
        
    }

    void set_skinned_mat(string obj_name, int Mat_Nr, Material Mat)
    {
        GameObject obj = GameObject.Find(obj_name);

        SkinnedMeshRenderer renderer = obj.GetComponentInChildren<SkinnedMeshRenderer>();

        Material[] mats = renderer.materials;

        mats[Mat_Nr] = Mat;

        renderer.materials = mats;
    }
}
