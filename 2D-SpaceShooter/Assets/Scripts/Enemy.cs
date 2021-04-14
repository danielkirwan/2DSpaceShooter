using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private Animator _explosion_anim;
    private Player _player;
    private Collider2D _collider;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private GameObject _enemylaserPrefab;
    [SerializeField] private GameObject _laserSpawnPoint;

    private float _fireRate = 3.0f;
    private float _canFire = -1;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _explosion_anim = GetComponentInChildren<Animator>();
        if (_explosion_anim == null)
        {
            Debug.Log("Enemy animator is null");
        }
        //StartCoroutine(FireLaser());
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        if (_collider == null)
        {
            Debug.Log("Collider is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Time.time > _canFire)
        {
            _fireRate = Random.Range(3f, 5f);
            _canFire = Time.time + _fireRate;
            Instantiate(_enemylaserPrefab, _laserSpawnPoint.transform.position, Quaternion.identity);
        }
    }


    void Move()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime);

        if (transform.position.x <= -12f)
        {
            float randPosY = Random.Range(-3.75f, 6f);
            transform.position = new Vector3(12f, randPosY, 0);
            //StartCoroutine(FireLaser());
        }
    }


    //IEnumerator FireLaser()
    //{
    //    float randNum = Random.Range(1f, 3f);
    //    yield return new WaitForSeconds(randNum);
    //    Instantiate(_enemylaserPrefab, _laserSpawnPoint.transform.position, Quaternion.identity);
    //    Debug.Log("Firing laser");
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
            if(_player != null)
            {
                _player.AddScore();
            }
            OnHit();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            OnHit();
        }
    }

    public void OnHit()
    {
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this._collider);
        _speed = 0.0f;
        Player.sfx[2].Play();
        Destroy(explosion, 1f);
        Destroy(this.gameObject, 0.5f);
    }


    private void OnEnable()
    {
        _collider.enabled = !_collider.enabled;
    }
}
