using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Steps : MonoBehaviour
{
    public GameObject firstStep; // ��������� ����� ��������
    public GameObject stepPrefab; // ������ ��������
    public int stepNum; // ʳ������ �������� ��� ����� ��������
    public float stepHeight = 0.5f; // ������ ��������
    public float stepLenght = 1f; // ������� ��������
    private void Start()
    {
        for (int i = 0; i < stepNum + 1; i++)
        {
            Instantiate(
                stepPrefab,
                firstStep.transform.position + new Vector3(
                    0, i * stepHeight, i * stepLenght),
                Quaternion.identity);
        }
    }
}
