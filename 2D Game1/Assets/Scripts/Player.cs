using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 0.5f;
    public GameObject explosion;

    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;

    private Weapon weapon;

    private BoxCollider2D boxCollider;

    private Vector3 playerPos;

    private int score;

    [SerializeField]
    private KeyCode keyCodeBoom = KeyCode.Z;
    
    public int Score
    {
        // score 값이 음수가 되지 않도록
        set => score = Mathf.Max(0, value);
        get => score;
    }


    private void Start()
    {
        playerPos = transform.position;
    }

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    // ???????? ???? ????
    void MoveControl()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(moveX, 0, 0);

        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(0, moveY, 0);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);

            SoundManager.instance.PlaySound();

            // GameManager.instance.KillPlayer();

            Destroy(collision.gameObject); // 적 사망
            
            InactivePlayer();

        }
    }

    

    void InactivePlayer() // ?????? ?????? ???? ?????? Player?? ???? ?????? ??????????
    {
        gameObject.SetActive(false);

        transform.position = playerPos; // Player?? ?????? ?????? ?? ?? ?????? ????.
    }

    void Update()
    {
        MoveControl();

        if(Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if(Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }
        
        // 폭탄 키를 눌러 폭탄 생성
        if(Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
    }
}
