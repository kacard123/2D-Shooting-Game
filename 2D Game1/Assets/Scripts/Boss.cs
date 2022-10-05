using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState { MoveToAppearPoint = 0, Phase01, Phase02}

public class Boss : MonoBehaviour
{
    [SerializeField]
    //private StageData stageData;
    
    private int damage = 1;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private float bossApearPoint = 2.5f;
    private BossState bossState = BossState.MoveToAppearPoint;
    private Movement2D movement2D;
    private BossWeapon bossWeapon;
    private BossHP bossHP;

    [SerializeField]
    private int scorePoint = 100; // 적 처치시 획득 점수

    private Player player; // 플레이어 점수(Score) 정보에 접근하기 위해

    //public void OnDie()
    //{
    //    // 보스 오브젝트 삭제
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Player"이면
        if(collision.CompareTag("Player"))
        {
            // 부딪힌 오브젝트 체력 감소(플레이어)
            collision.GetComponent<Player>(); // 10분 
            // 
        }
            
    }
    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();

        // Tip.현재 코드에서는 한번만 호출하기 때문에 OnDie에서 바로 호출해도 되지만
        // 오브젝트 풀링을 이용해 오브젝트를 재사용할 경우에는 최초 1번만 Find를 이용해
        // Player의 정보를 저장해두고 사용하는 것이 연산에 효율적이다.

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void ChangeState(BossState newState)
    {
        // Tip. 열거형 변수.ToString()을 하게 되면 열거형에 정의된
        // 변수 이름을 string으로 받아오게 된다.
        // ex) bossState가 현재 BossState.MoveToAppearPoint이면 "MoveToAppearPoint"

        // 이를 이용해 열거형의 이름과 코루틴 이름을 일치시켜
        // 열거형 변수에 따라 코루틴 함수 재생을 제어할 수 있다.

        // 이전에 재생 중이던 상태 종료
        StopCoroutine(bossState.ToString());
        // 상태 변경
        bossState = newState;
        // 새로운 상태 재생
        StartCoroutine(bossState.ToString());
    }

    private IEnumerator MoveToAppearPoint()
    {
        // 이동방향 설정 [코루틴 실행 시 1회 호출]
        movement2D.MoveTo(Vector3.down);

        while (true)
        {
            if (transform.position.y <= bossApearPoint)
            {
                //이동방향을 (0,0,0)으로 설정해 멈추도록 한다.
                movement2D.MoveTo(Vector3.zero);
                // Phase01 상태로 변경 
                ChangeState(BossState.Phase01);
            }
            yield return null;
        }
    }

    private IEnumerator Phase01()
    {
        // 원 형태의 방사 공격 시작
        bossWeapon.StartFiring(AttackType.CircleFire);

        while (true)
        {
            //// 보스의 현재 체력이 70% 이하가 되면
            //if (bossHP.CurrentHP <= bossHP.MaxHP * 0.7f)
            //{
            //    // 원 방사 형태의 공격 중지
            //    bossWeapon.StopFiring(AttackType.CircleFire);
            //    // Phase02로 변경
            //    ChangeState(BossState.Phase02);
            //}
            yield return null;
        }
    }

    //private IEnumerator Phase02()
    //{
    //    // 플레이어 위치를 기준으로 단일 발사체 공격 시작
    //    //bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

    //    // 처음 이동 방향을 오른쪽으로 설정
    //    Vector3 direction = Vector3.right;
    //    movement2D.MoveTo(direction);

    //    while (true)
    //    {
    //        // 좌 - 우 이동 중 양쪽 끝에 도달하게 되면 방향을 반대로 설정
    //        if(transform.position.x <= stageData.LimitMin.x ||
    //           transform.position.x >= stageData.LimitMax.x)
    //        {
    //            direction *= -1;
    //            movement2D.MoveTo(direction);
    //        }
    //    }
    //}
}
