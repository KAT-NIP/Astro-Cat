using UnityEngine;
using System.Collections;

public class CrowUserController : MonoBehaviour {

    public CrowCharacter crowCharacter;
    public float upDownInputSpeed = 3f;


    void Start()
    {
        crowCharacter = GetComponent<CrowCharacter>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            crowCharacter.Soar();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            crowCharacter.Attack();
        }

        if (Input.GetKey(KeyCode.H))
        {
            crowCharacter.Hit();
        }

        if (Input.GetKey(KeyCode.K))
        {
            crowCharacter.Death();
        }

        if (Input.GetKey(KeyCode.L))
        {
            crowCharacter.Rebirth();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            crowCharacter.EatStart();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            crowCharacter.EatEnd();
        }

        if (Input.GetKey(KeyCode.N))
        {
            crowCharacter.upDown = Mathf.Clamp(crowCharacter.upDown - Time.deltaTime * upDownInputSpeed, -1f, 1f);
        }
        if (Input.GetKey(KeyCode.U))
        {
            crowCharacter.upDown = Mathf.Clamp(crowCharacter.upDown + Time.deltaTime * upDownInputSpeed, -1f, 1f);
        }
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        crowCharacter.forwardAcceleration = v;
        crowCharacter.yawVelocity = h;

    }
}
