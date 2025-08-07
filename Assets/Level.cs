using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelNumber; // ����� ����
    private PoolsLevelGen gen; // ��������� �� ������ ����������
    private string playerTag = "Player"; // ��� ������

    // ����������� (����������� � ����������)
    public void Init(PoolsLevelGen generator, int number, string playerTagToUse)
    {
        gen = generator;
        levelNumber = number;
        playerTag = playerTagToUse;
        UpdateText();
    }
    private void UpdateText()
    {
        var tmp = GetComponentInChildren<TMP_Text>(true);
        if (tmp != null) tmp.text = Mathf.Abs(levelNumber).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag) && gen != null)
        {
            gen.SetCurrentLevel(levelNumber);
        }
    }
}
