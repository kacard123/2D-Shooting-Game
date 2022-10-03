using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteCollider : MonoBehaviour
{
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Rocket"이면
        if (collision.gameObject.tag == ("Rocket"))
        {
            SoundManager.instance.PlaySound();

            Instantiate(explosion, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == ("Player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            // Destroy(collision.gameObject);
            Destroy(gameObject);

            GameManager.instance.KillPlayer();
        }
    }
}
