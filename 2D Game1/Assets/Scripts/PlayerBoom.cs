using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoom : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curve;
    [SerializeField]
    private AudioClip boomAudio; // 사운드 파일
    private float boomDealy = 0.5f; // 폭탄 이동 시간(0.5초 후 폭발)
    private Animator animator;
    private AudioSource audioSource;

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

            // booomDelay 에 설정된 시간동안 startPosition부터 endPosition까지 이동
            // curve에 설정된 그래프처럼 처음엔 빠르게 이동하고, 목적지에 다다를수록 천천히 이동
            transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percent));

            yield return null;

        }

        // 이동이 완료된 후 애니메이션 변경
        animator.SetTrigger("onBoom");
        // 사운드 변경
        audioSource.clip = boomAudio;
        audioSource.Play();

    }

   public void OnBoom()
    {
        // 현재 게임 내에서 "Boss" 태그를 가진 오브젝트 정보를 가져온다
        GameObject[] boss = GameObject.FindGameObjectsWithTag("Boss");

        Destroy(gameObject);
        
    }
}
