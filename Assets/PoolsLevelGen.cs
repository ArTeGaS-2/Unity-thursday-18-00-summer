using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsLevelGen : MonoBehaviour
{
    public PoolsLevelGen Instance;
    [Header("Генерація сходів")]
    public GameObject zeroLevel;
    public GameObject levelPrefab;
    public int topLevelNum;
    public int currentLevelNum;
    public int bottomLevelNum;
    public float levelHeightStep = 7f;
    public int poolCapacity = 50;
    private void Start()
    {
        topLevelNum = 0;
        currentLevelNum = 0;
        bottomLevelNum = 50;
        Instance = this;
    }
    public void PlusCurrentLevel()
    {
        currentLevelNum++;
    }
    public void MinusCurrentLevel()
    {
        currentLevelNum--;
    }
}
