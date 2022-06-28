using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float minSpawnDistance;
    [SerializeField]
    float maxSpawnDistance;
    [SerializeField]
    float spawnRate = 2f;
    float timer;

    void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer)
        {
            SpawnEnemy();
            timer = Time.time + spawnRate;
        }

    }

    void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameManager.GameState state)
    {

    }

    void SpawnEnemy()
    {
        float ranDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        float ranDirection = Random.rotation.eulerAngles.y;
        Vector3 spawnPos = (Quaternion.Euler(0, ranDirection, 0) * new Vector3(ranDistance, 1, ranDistance));
        Enemy enemy = Instantiate(PrefabManager.Instance.EnemyPrefab[0], spawnPos, Quaternion.identity).GetComponent<Enemy>();

    }
}
