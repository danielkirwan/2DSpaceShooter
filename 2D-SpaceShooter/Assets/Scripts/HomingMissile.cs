using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed = 200f;
    private Transform _target;  
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FindTarget());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Enemy").transform;
        }

        if(_target != null)
        {
            Vector2 direction = (Vector2)_target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.right).z;

            rb.angularVelocity = -rotateAmount * _rotateSpeed;
            rb.velocity = transform.right * _speed;
        }
    }

    IEnumerator FindTarget()
    {
        yield return new WaitForSeconds(.5f);
        _target = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

}
