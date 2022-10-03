using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    List<GameObject> enemies = new List<GameObject>(); // ?? ???????? ???????? ???? ?????? ?????? ??????

    Vector3[] positions = new Vector3[5];

    public GameObject enemy;

    [SerializeField]
    private GameObject boss;

    public bool isSpawn = false;

    public float spawnDelay = 1.5f;
    float spawnTimer = 0f;

    //[SerializeField]
    //private GameObject textBossWarning; // 보스 등장 텍스트 오브젝트

    private void Awake()
    {
        if (SpawnManager.instance == null)
        {
            SpawnManager.instance = this;
        }

        //textBossWarning.SetActive(false);
        //boss.SetActive(false);
    }

    void Start()
    {
        Createpositions();
    }


    void Createpositions() // ???? ?????? ?????? ???????? ?????????? ????????
    {
        float viewPosY = 1.2f;
        float gapX = 1f / 6f;
        float viewPosX = 0f;

        for (int i = 0; i < positions.Length; i++)
        {
            viewPosX = gapX + gapX * i;

            Vector3 viewPos = new Vector3(viewPosX, viewPosY, 0);

            Vector3 WorldPos = Camera.main.ViewportToWorldPoint(viewPos);

            WorldPos.z = 0f;

            positions[i] = WorldPos;
        }
    }

    void SpawnEnemy() // isSpawn?? true?? ?? ???? ???????? ????
    {

        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);

                GameObject enemyObj = Instantiate(enemy, positions[rand], Quaternion.identity) as GameObject; // ?????? ?????????????? ??????(Quaternion rotation)

                enemies.Add(enemyObj);

                spawnTimer = 0f;
            }
            spawnTimer += Time.deltaTime;
        }

    }

    public void ClearEnemies()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                Destroy(enemies[i]);
            }
        }
        enemies.Clear();
    }


    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }
}
