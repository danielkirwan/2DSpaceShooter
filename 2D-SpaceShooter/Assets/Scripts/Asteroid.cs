using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _explosion;
    private SpawnManager _spawnManager;
    private Vignette _vignette;
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        _vignette = GameObject.Find("StartVignette").GetComponent<Vignette>();
        if (_vignette == null)
        {
            Debug.Log("Vignette is empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            GameObject explosion = Instantiate(_explosion, this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            _spawnManager.StartSpawning();
            _vignette.PlayVignetteAnimation();
            Destroy(this.gameObject, 0.3f);
            Destroy(explosion, 3f);
        }
    }


}
