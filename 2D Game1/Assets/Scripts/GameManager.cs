using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textBossWarning; // 보스 등장 경고 메세지

    public GameObject boss;

    private GameObject player;

    int score = 0;

    public bool isPlayerAlive = true;

    public TextMeshProUGUI scoreText;

    public static GameManager instance;

    public bool isSpawnBoss = false;

    [SerializeField]
    private GameObject panelBossHP; // 보스 체력 패널 오브젝트


    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }

        // 보스 등장 텍스트 비활성화
        textBossWarning.SetActive(false);
        // 보스 오브젝트 비활성화
        boss.SetActive(false);

        // 보스 체력 패널 비활성화
        panelBossHP.SetActive(false);
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Invoke("StartGame", 5f);
    }

    public void ResetGame()
    {
        SpawnManager.instance.ClearEnemies(); // SpawnManager???? ???? ???? ???????? ??

        score = 0;

        scoreText.text = string.Empty;

        TextControl.instance.Restart(); // TextControl???? ???? ??????

        Invoke("RetryGame", 3f); // 3?? ?? ???? ??????

        boss.SetActive(false);
    }

    void RetryGame()
    {
        StartGame();
        player.SetActive(true);
    }

    void StartGame()
    {
        SpawnManager.instance.isSpawn = true;
        MeteoriteSpawner.instance.isSpawn = true;
    }

    public void KillPlayer()
    {
        isPlayerAlive = false;
        SpawnManager.instance.isSpawn = false;
        MeteoriteSpawner.instance.isSpawn = false;
        TextControl.instance.ShowGameOver();
    }

    public void AddScore(int enemyScore) // ???? ?????? ?????? ?????? ???????? ????
    {
        score += enemyScore;
        scoreText.text = "Score : " + score;
    }

    private void Update()
    {
        // bool ??????
        if (score >= 200 && isSpawnBoss == false)
        {
            isSpawnBoss = true;
            StartCoroutine(SpawnBoss());
        }
    }


    IEnumerator SpawnBoss()
    {
        // 보스 등장 텍스트 활성화
        textBossWarning.SetActive(true);
        // 2초 대기
        yield return new WaitForSeconds(2.0f);

        // 보스 등장 텍스트 비활성화
        textBossWarning.SetActive(false);
        // 보스 체력 패널 활성화
        boss.SetActive(true);
        // 보스의 첫 번째 상태인 지정된 위치로 이동 실행
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
        // 보스 체력 패널 활성화
        panelBossHP.SetActive(true);
    }
}



