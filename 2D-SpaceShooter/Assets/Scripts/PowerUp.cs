using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
