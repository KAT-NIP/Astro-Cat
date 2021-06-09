using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public enum Type { plusTime, minusTime, plusVelocity, minusVelocity };
    public Type type;
    public int value; // 아이템 먹을 시 변화량

    void Start()
    {
        int randomType = Random.Range(0, 4); // 0 ~ 3 랜덤 아이템 기능
        if (randomType == 0)
        {
            type = Type.plusTime;
            value = 10;
        }
        else if(randomType == 1)
        {
            type = Type.minusTime;
            value = -10;
        }
        else if (randomType == 2)
        {
            type = Type.plusVelocity;
            value = 5;
        }
        else if (randomType == 1)
        {
            type = Type.minusVelocity;
            value = -5;
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime); // 회전 효과
    }


}
