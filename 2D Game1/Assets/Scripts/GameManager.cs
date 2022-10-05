using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textBossWarning; // ���� ���� ��� �޼���

    public GameObject boss;

    private GameObject player;

    int score = 0;

    public bool isPlayerAlive = true;

    public TextMeshProUGUI scoreText;

    public static GameManager instance;

    public bool isSpawnBoss = false;

    [SerializeField]
    private GameObject panelBossHP; // ���� ü�� �г� ������Ʈ


    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }

        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarning.SetActive(false);
        // ���� ������Ʈ ��Ȱ��ȭ
        boss.SetActive(false);

        // ���� ü�� �г� ��Ȱ��ȭ
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
        // ���� ���� �ؽ�Ʈ Ȱ��ȭ
        textBossWarning.SetActive(true);
        // 2�� ���
        yield return new WaitForSeconds(2.0f);

        // ���� ���� �ؽ�Ʈ ��Ȱ��ȭ
        textBossWarning.SetActive(false);
        // ���� ü�� �г� Ȱ��ȭ
        boss.SetActive(true);
        // ������ ù ��° ������ ������ ��ġ�� �̵� ����
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);
        // ���� ü�� �г� Ȱ��ȭ
        panelBossHP.SetActive(true);
    }
}



