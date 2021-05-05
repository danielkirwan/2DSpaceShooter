using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    public string waveName;
    public int numberOfEnemies;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
    
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Wave currentWave;
    private int currentWaveNumber;
    public GameObject spawnContainer;
    public Animator anim;
    public Text waveName;

    private float nextSpawnTime;

    private bool canSpawn = false;
    private bool startSpawn = false;
    private bool canAnimateWave = false;
    private UIManager _uiManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if(_uiManager == null)
        {
            Debug.Log("Uimanager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentWave = waves[currentWaveNumber];
        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && startSpawn)
        {
            if (currentWaveNumber + 1 != waves.Length)
            {
                if (canAnimateWave)
                {
                    waveName.text = waves[currentWaveNumber + 1].waveName;
                    anim.SetTrigger("WaveComplete");
                    canAnimateWave = false;
                }
            }
            else
            {
                _uiManager.GameOverText();
            }
            
        }
        

    }

    public void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    public void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity, spawnContainer.transform);
            currentWave.numberOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;
            if(currentWave.numberOfEnemies == 0)
            {
                canSpawn = false;
                canAnimateWave = true;
            }
        } 
    }

    public void StartSpawningWave()
    {
        canSpawn = true;
        startSpawn = true;
    }
}
