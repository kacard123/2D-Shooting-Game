using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if(collision.CompareTag("Enemy"))
        {
            // 부딪힌 오브젝트 사망처리 (적)
            Destroy(collision.gameObject);
            // 내 오브젝트 삭제(발사체)
            Destroy(gameObject);
        }
    }
}
