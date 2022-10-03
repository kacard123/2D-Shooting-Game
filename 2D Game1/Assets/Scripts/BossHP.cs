using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 1000; // �ִ� ü��
    private float currentHP; // ���� ü��
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHP = maxHP; // ���� ü���� �ִ� ü�°� ���� ����
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü�� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            // ü���� 0�̸� 
        }
    }

}

