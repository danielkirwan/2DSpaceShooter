using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _spawnContainer;
    // Start is called before the first frame update
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //spawn game objects every 5 seconds

    IEnumerator SpawnEnemy()
    {
        while (!_stopSpawning)
        {
            float randY = Random.Range(-3.75f, 6f);
            GameObject enemySpawned = Instantiate(_enemyPrefab, new Vector3(12f, randY, 0), Quaternion.identity);
            enemySpawned.transform.SetParent(_spawnContainer.transform);
            yield return new WaitForSeconds(5);
        }
    }

    public void StopSpawning()
    {
        _stopSpawning = true;
    }
    

}
