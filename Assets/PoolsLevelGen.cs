using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolsLevelGen : MonoBehaviour
{
    public PoolsLevelGen Instance;

    [Header("Посилання")]
    public GameObject levelPrefab; // Префаб одного рівня

    [Header("Налаштування")]
    public float levelHeightStep = 14f; // Висота між платформами
    [Range(2,500)]public int poolCapacity = 50; // Кількість інстансів в пулі
    public string playerTag = "Player"; // Тег гравця для тригерів

    [Header("Стан")]
    public int currentLevelNum = 0; // Поточний рівень, де зараз гравець
    public int topLevelNum = 0; // Найвищий індекс/рівень у вікні
    public int bottomLevelNum; // Найнижчий індекс/ рівень у вікні

    // --- Приватні структури
    readonly List<GameObject> pool = new List<GameObject>();
    readonly Stack<GameObject> free = new Stack<GameObject>();
    readonly Dictionary<int, GameObject> activeByLevel = 
        new Dictionary<int, GameObject>();

    private Vector3 basePosition; // Позиція першого згенерованого рівня
   
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
