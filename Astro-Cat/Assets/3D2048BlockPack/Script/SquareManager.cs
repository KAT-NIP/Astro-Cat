using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareManager : MonoBehaviour {

    public GameObject[] n;
    public GameObject Quit;
    public Text Score, Plus, WinText;

    public GameObject Win;

    // 레벨 1, 2, 3 클리어 여부
    bool[] levelClear = { false, false, false };

    bool move, stop;
    int x, y, i, j, k, l, score;
    GameObject[,] Square = new GameObject[4, 4];

    [Header("[Grid]")]
    public float setGridGap = 1.2f;
    public float setGridOffset = 1.8f;
    public bool setHorizontal = false;
    static float gridGap;
    static float gridOffset;
    static bool horizontal;
    public bool quterSwip;
    private GameObject talkObject; // 말풍선 object 
    private Text talkObjectText; // 말풍선 속 대사 object

    void Start()
    {
        //grid setting
        gridGap = setGridGap;
        gridOffset = setGridOffset;
        horizontal = setHorizontal;

        Spawn();
        Spawn();
        // 말풍서
        talkObject = GameObject.FindWithTag("talkPanel");
        talkObjectText = GameObject.Find("talkPanel/Text").GetComponent<Text>();
        //reset score
        Score.text = "0";
    }

    void Update()
    {
        // Escape
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (stop) return;

        // 레벨 클리어 조건 체크
        if(CheckLevelWin())
        {
            Win.SetActive(true);
        }
        // 마우스 클릭하면 Level Complete 문구 사라짐
        if(Input.GetMouseButtonDown(0))
        {
            Win.SetActive(false);
            //마우스 클릭 시 대화창 사라짐
            talkObject.SetActive(false);
        }

        DetectDirection();
        if (move)
        {
            move = false;
            Spawn();
            k = 0;
            l = 0;

            // score(점수 올라가는 애니메이션)
            if (score > 0)
            {
                Plus.text = "+" + score.ToString() + "    ";
                Plus.GetComponent<Animator>().SetTrigger("PlusBack");
                Plus.GetComponent<Animator>().SetTrigger("Plus");
                Score.text = (int.Parse(Score.text) + score).ToString();

                score = 0;
            }

            for (x = 0; x <= 3; x++) for (y = 0; y <= 3; y++)
                {
                    // when all tiles are full, K is zero(빈칸 체크)
                    if (Square[x, y] == null)
                    {
                        k++;
                        continue;
                    }

                    if (Square[x, y].tag == "Finish")
                        Square[x, y].tag = "Untagged";
                }

            if (k == 0)
            {
                // 게임 종료 조건(가로 세로로 합칠 수 있는 블록이 있는지 확인)
                for (y = 0; y <= 3; y++)
                    for (x = 0; x <= 2; x++)
                        if (Square[x, y].name == Square[x + 1, y].name)
                            l++;

                for (x = 0; x <= 3; x++)
                    for (y = 0; y <= 2; y++)
                        if (Square[x, y].name == Square[x, y + 1].name)
                            l++;

                // 빈칸이 없고(k == 0) 가로, 세로로 합칠 수 있는 블록이 없으면(l == 0) 게임 종료
                if (l == 0)
                {
                    stop = true;
                    Quit.SetActive(true);
                    return;
                }
            }
        }

    }

    // [x1, y1] Position before moving, [x2, y2] Position after moving.
    void MoveOrCombine(int x1, int y1, int x2, int y2)
    {
        // Move
        if (Square[x2, y2] == null && Square[x1, y1] != null)
        {
            move = true;
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2, false);
            Square[x2, y2] = Square[x1, y1];
            Square[x1, y1] = null;
        }

        // Combine
        if (Square[x1, y1] != null && Square[x2, y2] != null && Square[x1, y1].name == Square[x2, y2].name && Square[x1, y1].tag != "Finish" && Square[x2, y2].tag != "Finish")
        {
            move = true;
            for (j = 0; j <= 16; j++)
            {
                if (Square[x2, y2].name == n[j].name + "(Clone)")
                    break;
            }
            Square[x1, y1].GetComponent<Moving>().Move(x2, y2, true);
            Destroy(Square[x1, y1]);
            Destroy(Square[x2, y2]);
            Square[x1, y1] = null;
            Square[x2, y2] = Instantiate(n[j + 1], TargetPos(x2, y2), Quaternion.identity);
            Square[x2, y2].tag = "Finish";
            Square[x2, y2].GetComponent<Animator>().SetTrigger("Finish");
            score += (int)Mathf.Pow(2, j + 2);
        }
    }

    // Spawn
    void Spawn()
    {
        while (true)
        {
            x = Random.Range(0, 4);
            y = Random.Range(0, 4);

            if (Square[x, y] == null)
                break;
        }

        Square[x, y] = Instantiate(Random.Range(
            0, int.Parse(Score.text) > 800 ? 4 : 8) > 0 ? n[0] : n[1],
            //new Vector3(gridGap * x - gridOffset, 0, gridGap * y - gridOffset),
            TargetPos(x, y),
            Quaternion.identity
            );
        Square[x, y].GetComponent<Animator>().SetTrigger("Spawn");
    }

    // Restart
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetData()
    {
        if (PlayerPrefs.HasKey("Score"))
            PlayerPrefs.DeleteKey("Score");
    }

    public static Vector3 TargetPos(float _x, float _y)
    {
        Vector3 _targetPos;
        float newX = gridGap * _x - gridOffset;
        float newY = gridGap * _y - gridOffset;
        if (horizontal)
        {
            _targetPos = new Vector3(newX, 0, newY);
        }
        else
        {
            _targetPos = new Vector3(newX, newY, 0);
        }
        
        return _targetPos;
    }

    public void DetectDirection()
    {
        // 키보드 입력에 따라 이동방향 결(
        if (Input.GetKeyDown(KeyCode.UpArrow))  // 위
        {
            for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) for (i = 3; i >= y + 1; i--) MoveOrCombine(x, i - 1, x, i);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) // 아래
        {
            for (x = 0; x <= 3; x++) for (y = 3; y >= 1; y--) for (i = 0; i <= y - 1; i++) MoveOrCombine(x, i + 1, x, i);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) // 오른쪽
        {
            for (y = 0; y <= 3; y++) for (x = 0; x <= 2; x++) for (i = 3; i >= x + 1; i--) MoveOrCombine(i - 1, y, i, y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))   // 왼쪽
        {
            for (y = 0; y <= 3; y++) for (x = 3; x >= 1; x--) for (i = 0; i <= x - 1; i++) MoveOrCombine(i + 1, y, i, y);
        }
        else return;
    }

    public bool CheckLevelWin()
    {
        for(int i = 0; i <= 3; i++)
        {
            for(int j = 0; j <= 3; j++)
            {
                // 레벨1 클리어조건 (n[4] = 32)
                if(!levelClear[0] && Square[i, j] != null && Square[i, j].name == n[4].name + "(Clone)")
                {
                    WinText.text = "Level 1 Clear!";
                    levelClear[0] = true;
                    //talkObejct활성화, 텍스트 내용 수정
                    talkObject.SetActive(true);
                    talkObjectText.text = "허억 레벨1을 벌써 깨다니?\n레벨2는 쉽지 않을테니 각오해라!";
                    
                    return true;
                }
                // 레벨2 클리어조건 (n[5] = 64)
                if (!levelClear[1] && Square[i, j] != null && Square[i, j].name == n[5].name + "(Clone)")
                {
                    WinText.text = "Level 2 Clear!";
                    levelClear[1] = true;

                    talkObject.SetActive(true);
                    talkObjectText.text = "말도 안돼.. 하지만 레벨3는 쉽게 깨지 못 할거다!";
                    return true;
                }

                // 레벨1 클리어조건 (n[6] = 128)
                if (!levelClear[2] && Square[i, j] != null && Square[i, j].name == n[6].name + "(Clone)")
                {
                    WinText.text = "Level 3 Clear!";
                    levelClear[2] = true;

                    talkObject.SetActive(true);
                    talkObjectText.text = "가장 어려운 게임인 2048을 이렇게 클리어해버리다니...\n나의 패배를 인정하지..";
                    return true;
                }
            }
        }
        return false;
    }
}
