using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _spawnContainer;
    [SerializeField] private GameObject[] _powerups;
    private Enemy _enemy;
    // Start is called before the first frame update
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(GetBossComponent());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    IEnumerator GetBossComponent()
    {
        yield return new WaitForSeconds(2.1f);
        _enemy = GameObject.Find("EnemyContainer").GetComponentInChildren<Enemy>();
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
            yield return new WaitForSeconds(5);
            if (_enemy._isBoss)
            {
                StopSpawning();
            }
        }
    }


    IEnumerator SpawnPowerUpRoutine()
    {
        while (!_stopSpawning)
        {
            float randNum = Random.Range(5f, 7f);
            float randY = Random.Range(-3.75f, 6f);
            int randPowerUp = Random.Range(0, 7);
            Instantiate(_powerups[randPowerUp], new Vector3(12f, randY, 0), Quaternion.identity);
            yield return new WaitForSeconds(randNum);
        }
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }
    

}
