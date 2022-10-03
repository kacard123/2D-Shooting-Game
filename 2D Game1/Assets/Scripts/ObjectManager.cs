using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    public GameObject weaponPrefab;

    List<GameObject> bullets = new List<GameObject>(); // ?????? ?????? ???????? ????

    private void Awake()
    {
        if(ObjectManager.instance == null)
        {
            ObjectManager.instance = this;
        }
    }

    private void Start()
    {
        CreateBullets(5);  // ???? 5???? ????
    }

    void CreateBullets(int bulletCount)
    {
        for(int i = 0; i < bulletCount; i++)
        {
            // Instantite()?? ?????? ???? ?????????? ?????? ?????? ???? "as+ ??????????"?? ?????? ???? ?????????? ??
            GameObject bullet = Instantiate(weaponPrefab) as GameObject;

            bullet.transform.parent = transform;
            bullet.SetActive(false);

            bullets.Add(bullet);
        }
    }

    public void ClearBullets()
    {
        for(int i = 0; i < bullets.Count; i++)
        {
            bullets[i].SetActive(false); // ?????? ???? ????????????
        }
    }

    public GameObject GetBullet(Vector3 pos)
    {
        GameObject reqBullet = null;

        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i].activeSelf == false)
            {
                reqBullet = bullets[i]; // ???????????????? ?????? ???? reqBullet?? ????????

                break;
            }
        }
    
        if(reqBullet == null) // ???? ???? ????
        {
            GameObject newBullet = Instantiate(weaponPrefab) as GameObject;
            newBullet.transform.parent = transform;

            bullets.Add(newBullet);
            reqBullet = newBullet;
        }

        reqBullet.SetActive(true); // reqBullet ????

        reqBullet.transform.position = pos;
        return reqBullet;
    }

    void Update()
    {
        
    }
}
