using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;
    private Slider sliderHP;

    void Start()
    {
        sliderHP = GetComponent<Slider>();
    }

    /// <summary>
    /// Tip. �� ��Ȯ�� ������δ� �̺�Ʈ�� �̿��� ü�� ������ �ٲ� ���� UI ���� ����
    /// </summary>
    void Update()
    {
        // Slider UI�� ���� ü�� ������ ������Ʈ
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}
 
