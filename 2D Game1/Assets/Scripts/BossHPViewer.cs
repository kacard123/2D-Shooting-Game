using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPViewer : MonoBehaviour
{
    [SerializeField]
    private BossHP bossHP;
    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        // Slider UI�� ü�� ������ ������Ʈ
        sliderHP.value = bossHP.CurrentHP / bossHP.MaxHP;
    }
}

/*
 * File : BossHPViewer.cs
 * Desc
 *  : ������ ü�� ������ Slider UI�� ������Ʈ
 *  
 */
