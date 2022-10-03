using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 1000; // 최대 체력
    private float currentHP; // 현재 체력
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP; // 현재 체력을 최대 체력과 같게 설정
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력 0이하 = 플레이어 캐릭터 사망
        if(currentHP <= 0)
        {
            // 체력이 0이면 
        }
    }

}

