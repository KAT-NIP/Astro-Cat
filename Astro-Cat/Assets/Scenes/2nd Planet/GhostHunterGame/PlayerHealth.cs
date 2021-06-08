using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{

    private Animator playerAnimator;
    private MouseMoving playerMovement;
    private PlayerShooter playerShooter;
    public AudioClip playerDamaged;

    AudioSource audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<MouseMoving>();
        playerShooter = GetComponent<PlayerShooter>();
        audioSource = GetComponent<AudioSource>();
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
        if(collision.collider.CompareTag("Bullet")) 
        {
            if(!dead)
            {
                health -= 20;
                audioSource.clip = playerDamaged;
                audioSource.Play();

                Debug.Log("Remain Health = " + health);


                if (health <= 0)
                {
                    UpdateUI();
                    Die();
                    
                }
                    

                UpdateUI();
            }

        }

        // 유령하고 부딪히면 데미지
        else if (collision.collider.CompareTag("Ghost1") || collision.collider.CompareTag("Ghost2") || collision.collider.CompareTag("Ghost3")) 
        {
            if (!dead)
            {
                health -= 10;
                audioSource.clip = playerDamaged;
                audioSource.Play();

                Debug.Log("Remain Health = " + health);

                if (health <= 0)
                {
                    UpdateUI();
                    Die();

                }

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
                audioSource.clip = playerDamaged;
                audioSource.Play();
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
