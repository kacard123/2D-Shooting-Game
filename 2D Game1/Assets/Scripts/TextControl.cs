using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextControl : MonoBehaviour
{
    public static TextControl instance;

    public GameObject readyText;

    public GameObject gameOverText;

    public GameObject boss;

    private void Awake()
    {
        if(TextControl.instance == null)
        {
            TextControl.instance = this;
        }
    }

    void Start()
    {
        readyText.SetActive(false);

        gameOverText.SetActive(false);

        StartCoroutine(ShowReady()); // ?????? ?????? ???????? ???????? ?????????? ????.
    }

    IEnumerator ShowReady()
    {
        int count = 0;
        while(count < 3)
        {
            readyText.SetActive(true);
            yield return new WaitForSeconds(0.5f);

            readyText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }

    public void ShowGameOver()
    {
        gameOverText.SetActive(true);
    }

    // Update is called once per frame
    public void Restart()
    {
        gameOverText.SetActive(false); // ???????? ?????? ??????
        StartCoroutine(ShowReady()); //  ?????? ?????? ???????? ???? ??????
    }
}
