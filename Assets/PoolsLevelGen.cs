using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private void BuildPool()
    {
        for (int i = 0; i < poolCapacity; i++)
        {
            var go = Instantiate(levelPrefab, transform); // ������� ��'���
            go.SetActive(false); // ³������ ��'���
            pool.Add(go); // ���� �� ������
            free.Push(go); // ���� �� �����(� �����)
        }
    }
    private void RecomputeWindow()
    {

    }
    private void PlaceAndInit(GameObject go, int levelNumber)
    {
        go.transform.position = basePosition + Vector3.up * (
            levelNumber * levelHeightStep);
        go.transform.rotation = Quaternion.identity;
        go.SetActive(true);

        var lvl = go.GetComponentInChildren<Level>(true);
        if (lvl != null) lvl.Init(this, levelNumber, playerTag);

        UpdateTextIfAny(go, levelNumber);
    }
    private void ReleaseLevel(int levelNumber)
    {
        if (!activeByLevel.TryGetValue(levelNumber, out var go)) return;
        activeByLevel.Remove(levelNumber);
        go.SetActive(false);
        free.Push(go);
    }
    private int FindFarthestActiveFrom(int pivot)
    {
        int farKey = int.MaxValue; // ��������
        int farDist = -1; // ̳������� �������
        foreach (var kv in activeByLevel)
        {
            int d = Mathf.Abs(kv.Key - pivot); // ³������ �� ������
            if (d > farDist) // ���� ��� �� ���, �� ������� ��������
            {
                farDist = d; 
                farKey = kv.Key; // ����� ��������
            }
        }
        return farKey; // ��������� ����� ����, ������� ���������� �� ������
    }
    private void UpdateTextIfAny(GameObject root, int num)
    {
        // ���� � ������ � TMP_Text - ������ ����� (������� � �������)
        var tmp = root.GetComponentInChildren<TMP_Text>(true);
        if (tmp != null) tmp.text = Mathf.Abs(num).ToString();
    }
}
