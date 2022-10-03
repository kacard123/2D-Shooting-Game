using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteSpawner : MonoBehaviour
{
    public static MeteoriteSpawner instance;

    List<GameObject> meteorites = new List<GameObject>(); // ?? ???????? ???????? ???? ?????? ?????? ??????

    Vector3[] positions = new Vector3[5];

    public GameObject meteorite;

    public bool isSpawn = false;

    public float spawnDelay = 3f;
    float spawnTimer = 0f;

    private void Awake()
    {
        if (MeteoriteSpawner.instance == null)
        {
            MeteoriteSpawner.instance = this;
        }
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

    void SpawnMeteorite() // isSpawn?? true?? ?? ???? ???????? ????
    {
        if (isSpawn == true)
        {
            if (spawnTimer > spawnDelay)
            {
                int rand = Random.Range(0, positions.Length);

                GameObject meteoriteObj = Instantiate(meteorite, positions[rand], Quaternion.identity) as GameObject; // ?????? ?????????????? ??????(Quaternion rotation)

                meteorites.Add(meteoriteObj);

                spawnTimer = 0f;
            }

            spawnTimer += Time.deltaTime;
        }

    }

    public void ClearMeteorites()
    {
        for (int i = 0; i < meteorites.Count; i++)
        {
            if (meteorites[i] != null)
            {
                Destroy(meteorites[i]);
            }
        }
        meteorites.Clear();
    }


    // Update is called once per frame
    void Update()
    {
        SpawnMeteorite();
    }
}
