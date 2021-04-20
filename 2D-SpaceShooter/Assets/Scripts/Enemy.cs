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
    [SerializeField] private GameObject _shieldPrefab;

    private float _fireRate = 3.0f;
    private float _canFire = -1;

    private float _fireRatePowerUp = 2f;
    private float _canFireAtPowerup = -1f;

    private float _bossFireRateMultiShot = 5f;
    private float _canFireBoss = -1f;

    [Header("Bools")]
    [SerializeField] private bool _hasShield = false;
    [SerializeField] private bool _canDodge = false;
    [SerializeField] public bool _isBoss = false;
    [Space]
    [SerializeField] private int _health;
    

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _explosion_anim = GetComponentInChildren<Animator>();
        if (_explosion_anim == null)
        {
            Debug.Log("Enemy animator is null");
        }
        if(_hasShield == true)
        {
            HasShield();
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
        if (!_isBoss)
        {
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(3f, 5f);
                _canFire = Time.time + _fireRate;
                Instantiate(_enemylaserPrefab, _laserSpawnPoint.transform.position, Quaternion.identity);
            }
        }else if (_isBoss)
        {
            if(Time.time > _canFireBoss)
            {
                _canFireBoss = Time.time + _bossFireRateMultiShot;
                for(int i = 0; i <18; i++)
                {
                    Instantiate(_enemylaserPrefab, transform.position, Quaternion.Euler(0, 0, (i * 20)));
                }
            }
        }

    }


    void Move()
    {
        if (_canDodge)
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 10f, Color.red);

            RaycastHit2D hitCircle = Physics2D.CircleCast(transform.position, 2, transform.TransformDirection(Vector2.left), 1 << LayerMask.NameToLayer("Laser"));
            RaycastHit2D hitRay = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 10f, 1 << LayerMask.NameToLayer("PowerUp"));

            if(hitRay.collider != null)
            {


                Debug.Log("Hit something");
                if (hitRay.collider.gameObject.CompareTag("Ammo") || hitRay.collider.gameObject.CompareTag("Shield") || hitRay.collider.gameObject.CompareTag("Sboost"))
                {
                    Debug.Log("Detected " + hitRay.collider.name);
                    if(Time.time > _canFireAtPowerup)
                    {
                        _canFireAtPowerup = Time.time + _fireRatePowerUp;
                        Instantiate(_enemylaserPrefab, _laserSpawnPoint.transform.position, Quaternion.identity);
                    }
                    
                }
            }
            
            if(hitCircle.collider != null)
            {
                

                if (hitCircle.collider.gameObject.CompareTag("Laser"))
                {
                    Vector3 hitCirclePoint = hitCircle.point;
                    //Debug.Log("Hit point is " + hitCirclePoint);
                    //Debug.Log("Enemy pos is " + this.transform.position);
                    if (this.transform.position.y >= hitCirclePoint.y)
                    {
                        LeanTween.move(this.gameObject, new Vector3(this.transform.position.x + -1f, this.transform.position.y + 2f, this.transform.position.z), 0.5f);
                    }else if(this.transform.position.y <= hitCirclePoint.y)
                    {
                        LeanTween.move(this.gameObject, new Vector3(this.transform.position.x + -1f, this.transform.position.y + -2f, this.transform.position.z), 0.5f);
                    }
                    _canDodge = false;
                }
            }

        }

        transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime);

        if (transform.position.x <= -12f)
        {
            float randPosY = Random.Range(-3.75f, 6f);
            transform.position = new Vector3(12f, randPosY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            if (_hasShield)
            {
                DeactivateShield();
                Destroy(collision.gameObject);
                return;
            }
            if(_health > 1)
            {
                _health--;
                Destroy(collision.gameObject);
                Debug.Log("Enemy health is " + _health);
                return;
            }else if(_health <= 1)
            {
                Destroy(collision.gameObject);
                if (_player != null)
                {
                    _player.AddScore();
                }
                OnHit();
            }

            
        }
        else if (collision.gameObject.tag == "Player")
        {
            if (_hasShield)
            {
                DeactivateShield();
                return;
            }
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            if(_health > 1)
            {
                _health--;
                return;
            }else if(_health <= 1)
            {
                OnHit();
            }
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

    public void HasShield()
    {
        _hasShield = true;
        _shieldPrefab.SetActive(true);
    }

    void DeactivateShield()
    {
        _shieldPrefab.SetActive(false);
        _hasShield = false;   
    }

    private void OnDrawGizmos()
    {
        if (_canDodge)
        {
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }
}
