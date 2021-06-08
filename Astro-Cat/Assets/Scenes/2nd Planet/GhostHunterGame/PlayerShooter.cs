using UnityEngine;

// 주어진 Gun 오브젝트를 쏘거나 재장전
// 알맞은 애니메이션을 재생하고 IK를 사용해 캐릭터 양손이 총에 위치하도록 조정
public class PlayerShooter : MonoBehaviour
{
    public Gun gun; // 사용할 총
    public Transform gunPivot; // 총 배치의 기준점

    private Animator playerAnimator; // 애니메이터 컴포넌트

    private void Start()
    {
        // 사용할 컴포넌트들을 가져오기
        playerAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        // 슈터가 활성화될 때 총도 함께 활성화
        gun.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // 슈터가 비활성화될 때 총도 함께 비활성화
        gun.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!UIManager.GameClear)
        {
            // 입력을 감지하고 총 발사하거나 재장전
            if (Input.GetButton("Fire1"))
            {
                gun.Fire();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                if (gun.Reload())
                {
                    playerAnimator.SetTrigger("Reload");

                }
            }

            UpdateUI();
        }

    }

    // 탄약 UI 갱신
    private void UpdateUI()
    {
        if (gun != null && UIManager.instance != null)
        {
            // UI 매니저의 탄약 텍스트에 탄창의 탄약을 표시
            UIManager.instance.UpdateAmmoText(gun.magAmmo);
        }


    }
}