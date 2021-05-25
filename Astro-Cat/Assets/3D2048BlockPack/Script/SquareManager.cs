using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareManager : MonoBehaviour {

    public GameObject[] n;
    public GameObject Quit;
    public Text Score, Plus;

    bool wait, move, stop;
    int x, y, i, j, k, l, score;
    Vector3 firstPos, gap;
    GameObject[,] Square = new GameObject[4, 4];

    [Header("[Grid]")]
    public float setGridGap = 1.2f;
    public float setGridOffset = 1.8f;
    public bool setHorizontal = false;
    static float gridGap;
    static float gridOffset;
    static bool horizontal;
    public bool quterSwip;


    void Start () {
        //grid setting
        gridGap = setGridGap;
        gridOffset = setGridOffset;
        horizontal = setHorizontal;

        Spawn();
        Spawn();

        //reset score
        Score.text = "0";
    }

	void Update () {

        // Escape
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if (stop) return;

        DetectDirection();
        if (move)
        {
            move = false;
            Spawn();
            k = 0;
            l = 0;

            // score
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
                    //  when all tiles are full, K is zero
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
                //no horizontal or vertical joining block, l becomes 0 and the game is over.
                for (y = 0; y <= 3; y++)
                    for (x = 0; x <= 2; x++)
                        if (Square[x, y].name == Square[x + 1, y].name)
                            l++;

                for (x = 0; x <= 3; x++)
                    for (y = 0; y <= 2; y++)
                        if (Square[x, y].name == Square[x, y + 1].name)
                            l++;

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
        wait = false;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) for (i = 3; i >= y + 1; i--) MoveOrCombine(x, i - 1, x, i);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            for (x = 0; x <= 3; x++) for (y = 3; y >= 1; y--) for (i = 0; i <= y - 1; i++) MoveOrCombine(x, i + 1, x, i);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            for (y = 0; y <= 3; y++) for (x = 0; x <= 2; x++) for (i = 3; i >= x + 1; i--) MoveOrCombine(i - 1, y, i, y);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            for (y = 0; y <= 3; y++) for (x = 3; x >= 1; x--) for (i = 0; i <= x - 1; i++) MoveOrCombine(i + 1, y, i, y);
        }
        else return;
    }
}
