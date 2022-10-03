using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10; // �ִ� ü��
    private float currentHP; // ���� ü��
    private SpriteRenderer spriteRenderer;

    public float MaxHP => maxHP; //  maxHP������ ������ �� �ִ� ������Ƽ(Get�� ����)
    public float CurrentHP => currentHP; // currentHP ������ ������ �� �ִ� ������Ƽ(Get�� ����)

    void Start()
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

        // ü���� 0���� = �÷��̾� ĳ���� ���
        if(currentHP <= 0)
        {
            Debug.Log("Player HP : 0..Die");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
