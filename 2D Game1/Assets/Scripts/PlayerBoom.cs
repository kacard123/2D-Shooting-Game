using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio; // ���� ����
    private float boomDealy = 0.5f; // ��ź �̵� �ð�(0.5�� �� ����)
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField]
    private int damage = 100; // ��ź ������

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine("MoveToCenter");
    }

    private IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = Vector3.zero;
        float current = 0;
        float percent = 0;
        
        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / boomDealy;

            // booomDelay �� ������ �ð����� startPosition���� endPosition���� �̵�
            // curve�� ������ �׷���ó�� ó���� ������ �̵��ϰ�, �������� �ٴٸ����� õõ�� �̵�
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));

            yield return null;

        }

        // �̵��� �Ϸ�� �� �ִϸ��̼� ����
        animator.SetTrigger("onBoom");
        // ���� ����
        audioSource.clip = boomAudio;
        audioSource.Play();

    }

   public void OnBoom()
    {
        // ���� ���� ������ �����ϴ� ���� �߻�ü�� ��� �ı�
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("BossWeapon");
        for (int i = 0; i < weapons.Length; ++i)
        {
            weapons[i].GetComponent<BossWeapon>().OnDie();
        }

        // ���� ���� ������ "Boss" �±׸� ���� ������Ʈ ������ �����´�
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            // ������ ü���� damage��ŭ ���ҽ�Ų��
            boss.GetComponent<BossHP>().TakeDamage(damage);
        }

        // Boos ������Ʈ ����
        Destroy(gameObject);

    }
}
