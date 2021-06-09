using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public enum Type { plusTime, minusTime, plusVelocity, minusVelocity };
    public Type type;


    void Start()
    {
        int randomType = Random.Range(0, 4); // 0 ~ 3 랜덤 아이템 기능
        if (randomType == 0)
        {
            type = Type.plusTime;

        }
        else if(randomType == 1)
        {
            type = Type.minusTime;

        }
        else if (randomType == 2)
        {
            type = Type.plusVelocity;

        }
        else if (randomType == 1)
        {
            type = Type.minusVelocity;

        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime); // 회전 효과
    }


}
