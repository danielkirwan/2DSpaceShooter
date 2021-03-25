using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player speed")]
    [SerializeField] private float _speed;

    [Header("GameObjects")]
    public GameObject _laserPrefab;
    [SerializeField] private GameObject _laserPlacementPosition;

    private float _horizontalMovement;
    private float _verticalMovement;

    [Header("FireRates")]
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _nextFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        //set the players position when initiated 
        transform.position = new Vector3(-9, 0, 0);
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
        Instantiate(_laserPrefab, _laserPlacementPosition.transform.position, Quaternion.Euler(0,0,-90));
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

}
