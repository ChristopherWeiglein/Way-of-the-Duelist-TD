using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private WaveScript waveScript;
    [SerializeField]private float spawnRate = 1.0f;

    public int WaveNumber { get; private set; } = 0;
    public bool SpawningEnemies { get; private set; } = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        waveScript = Resources.Load<WaveScript>("SceneData/WaveData/" + SceneManager.GetActiveScene().name);
        GameObject.Find("DataPanel").GetComponent<PreviewManager>().ShowNextWave(waveScript.waveEnemyList[WaveNumber].waveList);
    }


    private void OnEnable()
    {
        GameManager.OnWaveStart += OnWaveStart;
    }

    private void OnDisable()
    {
        GameManager.OnWaveStart -= OnWaveStart;
    }

    public void OnWaveStart()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        SpawningEnemies = true;
        foreach (WaveScript.EnemyAmountPair enemyAmountPair in waveScript.waveEnemyList[WaveNumber].waveList)
        {
            for (int i = 0; i < enemyAmountPair.amount; i++)
            {
                yield return new WaitForSeconds(spawnRate);
                EnemyFactory.instance.CreateEnemy(enemyAmountPair.enemy, gameObject);
            }
        }
        while(transform.childCount > 0)
            yield return null;
        GameManager.TryEndWave();
        WaveNumber++;
        ShowPreview();
    }

    private void ShowPreview()
    {
        GameObject.Find("DataPanel").GetComponent<PreviewManager>().ShowNextWave(waveScript.waveEnemyList[WaveNumber].waveList);
    }
}
