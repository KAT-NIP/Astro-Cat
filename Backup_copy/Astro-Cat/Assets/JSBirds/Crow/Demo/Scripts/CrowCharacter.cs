using UnityEngine;
using System.Collections;

public class CrowCharacter : MonoBehaviour {
    public Animator crowAnimator;
    public float crowSpeed = 1f;
    Rigidbody crowRigid;
    public bool isFlying = false;
    public float upDown = 0f;
    public float forwardAcceleration = 0f;
    public float yawVelocity = 0f;
    public float groundCheckDistance = 5f;
    public bool isGrounded = true;
    public float forwardSpeed = 0f;
    public float maxForwardSpeed = 3f;
    public float meanForwardSpeed = 1.5f;
    public float speedDumpingTime = .1f;
    public float groundCheckOffset = 0.1f;
    float soaringTime = 0f;
    public bool isLived = true;

    void Start()
    {
        crowAnimator = GetComponent<Animator>();
        crowAnimator.speed = crowSpeed;
        crowRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        soaringTime = soaringTime + Time.deltaTime;
        GroundedCheck();
    }

    void GroundedCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position+Vector3.up*groundCheckOffset, Vector3.down, out hit, groundCheckDistance))
        {
            if (!isFlying || (isFlying && soaringTime>1f))
            {                
                Landing();
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
            crowAnimator.SetBool("IsGrounded", false);
        }
    }

    public void SpeedSet(float animSpeed)
    {
        crowAnimator.speed = animSpeed;
    }

    public void Landing()
    {
        crowAnimator.SetBool("IsGrounded", true);
        crowAnimator.SetBool("IsFlying", false);

        crowAnimator.applyRootMotion = true;
        crowRigid.useGravity = true;
        isFlying = false;
    }

    public void Soar()
    {
        if (isGrounded && isLived)
        {
            soaringTime = 0f;
            crowAnimator.SetBool("IsGrounded", false);
            crowAnimator.SetBool("IsFlying", true);
            crowAnimator.SetTrigger("Soar");
            crowRigid.useGravity = false;
            isGrounded = false;
            forwardAcceleration =0f;
            forwardSpeed =0f;
            upDown = 0f;
            crowAnimator.applyRootMotion = false;
            isFlying = true;
        }
    }

    public void Attack()
    {
        crowAnimator.SetTrigger("Attack");
    }

    public void Hit()
    {
        crowAnimator.SetTrigger("Hit");
    }


    public void Death()
    {
        crowAnimator.SetBool("IsLived",false);
        isLived = false;
    }

    public void Rebirth()
    {
        crowAnimator.SetBool("IsLived", true);
        isLived = true;
    }

    public void EatStart()
    {
        crowAnimator.SetBool("IsEating", true);
    }

    public void EatEnd()
    {
        crowAnimator.SetBool("IsEating", false);
    }


    public void Move()
    {
        crowAnimator.SetFloat("Forward", forwardAcceleration);
        crowAnimator.SetFloat("Turn", yawVelocity);
        crowAnimator.SetFloat("UpDown", upDown);
        crowAnimator.SetFloat("UpVelocity", crowRigid.velocity.y);

        if (isFlying)
        {
            if (soaringTime < 1f)
            {
                forwardSpeed=soaringTime*meanForwardSpeed;
                upDown = soaringTime;

            }

            if (forwardAcceleration < 0f)
            {
                crowRigid.velocity = transform.up * upDown + transform.forward * forwardSpeed;
            }
            else
            {
                crowRigid.velocity = transform.up * (upDown + (forwardSpeed - meanForwardSpeed)) + transform.forward * forwardSpeed;
            }
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * yawVelocity * 100f);

            forwardSpeed = Mathf.Lerp(forwardSpeed, 0f, Time.deltaTime * speedDumpingTime);
            forwardSpeed = Mathf.Clamp(forwardSpeed + forwardAcceleration * Time.deltaTime, 0f, maxForwardSpeed);
            upDown = Mathf.Lerp(upDown, 0, Time.deltaTime * 3f);

       }
    }
}
