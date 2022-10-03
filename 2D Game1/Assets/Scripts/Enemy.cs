using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int destroyScore = 100;

    public float moveSpeed = 0.5f;

    public GameObject explosion;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            SoundManager.instance.PlaySound();

            GameManager.instance.AddScore(destroyScore);

            // Rocket Tag ?? ?????????? ?? ?????? ????
            Instantiate(explosion, transform.position, Quaternion.identity);

            // Rocket ????
            // Destroy(col.gameObject);
            collision.gameObject.SetActive(false);

            // ???? ???? ????
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            // Destroy(collision.gameObject);
            GameManager.instance.KillPlayer();
        }
    }

    void MoveControl()
    {
        float yMove = moveSpeed * Time.deltaTime;
        transform.Translate(0, -yMove, 0);
    }

    private void Update()
    {
        MoveControl();
    }
}
