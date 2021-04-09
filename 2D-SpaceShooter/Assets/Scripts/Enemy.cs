using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private Animator _explosion_anim;
    private Player _player;
    private Collider2D _collider;
    [SerializeField] private SpriteRenderer _enemySprite;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _explosion_anim = GetComponentInChildren<Animator>();
        //if (_explosion_anim == null)
        //{
        //    Debug.Log("Enemy animator is null");
        //}
        //_enemySprite = GetComponentInChildren<SpriteRenderer>();
        //if(_enemySprite == null)
        //{
        //    Debug.Log("Sprite Renderer is empty");
        //}
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
            Destroy(collision.gameObject);
            if(_player != null)
            {
                _player.AddScore();
            }
            _explosion_anim.SetTrigger("OnDeath");
            Destroy(this._collider);
            _speed = 0.0f;
            //_enemySprite.gameObject.SetActive(false);
            Destroy(this.gameObject,1.5f);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            _explosion_anim.SetTrigger("OnDeath");
            Destroy(this._collider);
            _speed = 0.0f;
            Destroy(this.gameObject, 1.5f);
        }
    }


    private void OnEnable()
    {
        _collider.enabled = !_collider.enabled;
    }
}
