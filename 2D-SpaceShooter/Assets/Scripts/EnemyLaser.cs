using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    private bool _fireRight = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime, Space.World);
        transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime);
        
    }

    public void MoveLaserRight()
    {
        Debug.Log("Firing laser right");
        _fireRight = true;
    }

    public void MoveLaserLeft()
    {
        _fireRight = false;
    }



}
