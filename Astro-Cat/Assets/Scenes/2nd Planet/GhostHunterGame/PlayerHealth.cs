using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{

    private Animator playerAnimator;
    private MouseMoving playerMovement;
    private PlayerShooter playerShooter;

    // Start is called before the first frame update
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<MouseMoving>();
        playerShooter = GetComponent<PlayerShooter>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDamage(float damage, Vector3 hitPoint, Vector3 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);

    }


    public override void Die()
    {
        base.Die();
        playerMovement.enabled = false;
        playerShooter.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet")) // Ghost 3
        {
            if(!dead)
            {
                health -= 20;
                Debug.Log("Remain Health = " + health);

                if(health <= 0)
                {
                    UpdateUI();
                    Die();
                    
                }
                    

                Debug.Log("playerhealth" + health);
                UpdateUI();
            }

        }

        else if (collision.collider.CompareTag("Devil")) // Ghost1,2
        {
            if (!dead)
            {
                health -= 20;
                Debug.Log("Remain Health = " + health);

                if (health <= 0)
                {
                    UpdateUI();
                    Die();

                }


                Debug.Log("playerhealth" + health);
                UpdateUI();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BossAttack") // Boss
        {
            if (!dead)
            {
                health -= 20;
                Debug.Log("Remain Health = " + health);

                if(health <= 0)
                {
                    UpdateUI();
                    Die();
                    
                }

                Debug.Log("playerhealth" + health);
                UpdateUI();
            }

            Debug.Log("보스공격받음");
        }
    }
    private void UpdateUI()
    {
        UIManager.instance.UpdateLifeImage();
    }
}
