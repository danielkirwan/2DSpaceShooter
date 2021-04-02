using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player attributes")]
    [SerializeField] private float _speed;
    [SerializeField] private int _lives = 3;
    private float _speedMultiplier = 2f;

    [Space]

    [Header("GameObjects")]
    public GameObject _laserPrefab;
    [SerializeField] private GameObject _laserPlacementPosition;
    [SerializeField] private GameObject _tripleShotPrefab;

    [Space]

    [Header("FireRates")]
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _nextFire = -1f;

    [Space]

    private SpawnManager _spawnManager;
    private float _horizontalMovement;
    private float _verticalMovement;

    [Header("Tripleshot active")]
    [SerializeField] private bool _isTripleShotActive = false;
    private bool _isSpeedBoostActive = false;


    // Start is called before the first frame update
    void Start()
    {
        //set the players position when initiated 
        transform.position = new Vector3(-9, 0, 0);
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.Log("Spawn manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            SpawnLaser();
        }
    }

    void SpawnLaser()
    {
        _nextFire = Time.time + _fireRate;
        //Instantiate(_laserPrefab, _laserPlacementPosition.transform.position, Quaternion.Euler(0,0,-90));

        if (_isTripleShotActive)
        {
            Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else{
            Instantiate(_laserPrefab, _laserPlacementPosition.transform.position, Quaternion.identity);
        }
    }

    void PlayerMovement()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_horizontalMovement, _verticalMovement, 0) * _speed * Time.deltaTime);


        if (transform.position.y >= 8)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }
        else if (transform.position.y <= -5f)
        {
            transform.position = new Vector3(transform.position.x, 8f, transform.position.z);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.25f, 2), transform.position.y, transform.position.z);

    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            _spawnManager.StopSpawning();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(PowerdownTripleShotRoutine());
    }


    IEnumerator PowerdownTripleShotRoutine()
    {
        yield return new WaitForSeconds(5);
        _isTripleShotActive = false;
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        _speed *= _speedMultiplier;
        StartCoroutine(SpeedBoostDeactivateRoutine());
    }

    IEnumerator SpeedBoostDeactivateRoutine()
    {
        yield return new WaitForSeconds(5);
        _isSpeedBoostActive = false;
        _speed /= _speedMultiplier;
    }

}
