using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;



    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        //Vector3 camAngle = transform.rotation.eulerAngles;
        //float x = camAngle.x - target.transform.rotation.y;

        //if (x < 180f)
        //{
        //    x = Mathf.Clamp(x, -1f, 70f);
        //}
        //else
        //{
        //    x = Mathf.Clamp(x, 335f, 361f);
        //}
        //transform.rotation = Quaternion.Euler(camAngle.x - target.transform.rotation.y, camAngle.y + target.transform.rotation.x, camAngle.z);
    }
}
