using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _spawnContainer;
    [SerializeField] private GameObject[] _powerups;

    public int[] table = 
        { 
        40, //ammo
        20, //triple shot
        10, //speed
        10, //shield
        10, //powerdown
        5, //heart
        5 //homing missle
    };
    private int totalWeight;
    private int randomNumber;
    private Enemy _enemy;
    // Start is called before the first frame update
    private bool _stopSpawning = false;
    void Start()
    {
        foreach (var item in table)
        {
            totalWeight += item;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        //StartCoroutine(GetBossComponent());
       // StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator GetBossComponent()
    {
        yield return new WaitForSeconds(5f);
        //_enemy = GameObject.Find("EnemyContainer").GetComponentInChildren<Enemy>();
        _enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        if (_enemy == null)
        {
            Debug.Log("Enemy is null");
        }
    }

    //spawn game objects every 5 seconds

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);

        while (!_stopSpawning)
        {
            float randY = Random.Range(-3.75f, 6f);
            GameObject enemySpawned = Instantiate(_enemyPrefab, new Vector3(12f, randY, 0), Quaternion.identity);
            enemySpawned.transform.SetParent(_spawnContainer.transform);
            //if (_enemy._isBoss)
            //{
            //    StopSpawning();
            //}
            yield return new WaitForSeconds(5);
            
        }
    }


    IEnumerator SpawnPowerUpRoutine()
    {
        while (!_stopSpawning)
        {
            float randNum = Random.Range(3f, 5f);
            ChoosePowerUp();
            //int randPowerUp = Random.Range(0, 7);
            //Instantiate(_powerups[randPowerUp], new Vector3(12f, randY, 0), Quaternion.identity);
            yield return new WaitForSeconds(randNum);
        }
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }
    
    void ChoosePowerUp()
    {
        //int spawnRate = Random.Range(1,101);
        float randY = Random.Range(-3.75f, 6f);

        randomNumber = Random.Range(0, totalWeight);
        //Debug.Log("Random number is " + randomNumber);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Instantiate(_powerups[i], new Vector3(12f, randY, 0), Quaternion.identity);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }

    }
}
