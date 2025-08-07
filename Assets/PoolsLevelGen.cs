using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsLevelGen : MonoBehaviour
{
    public PoolsLevelGen Instance;

    [Header("���������")]
    public GameObject levelPrefab; // ������ ������ ����

    [Header("������������")]
    public float levelHeightStep = 14f; // ������ �� �����������
    [Range(2,500)]public int poolCapacity = 50; // ʳ������ �������� � ���
    public string playerTag = "Player"; // ��� ������ ��� �������

    [Header("����")]
    public int currentLevelNum = 0; // �������� �����, �� ����� �������
    public int topLevelNum = 0; // �������� ������/����� � ���
    public int bottomLevelNum; // ��������� ������/ ����� � ���

    // --- ������� ���������
    readonly List<GameObject> pool = new List<GameObject>();
    readonly Stack<GameObject> free = new Stack<GameObject>();
    readonly Dictionary<int, GameObject> activeByLevel = 
        new Dictionary<int, GameObject>();

    private Vector3 basePosition; // ������� ������� ������������� ����
   
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        basePosition = new Vector3(0,7,0);

        // BuildPool();

        currentLevelNum = 0;
        // RecomputeWindow();
    }
    public void SetCurrentLevel(int number)
    {

    }
}
