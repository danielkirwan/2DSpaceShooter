using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontalMovement;
    private float _verticalMovement;
    // Start is called before the first frame update
    void Start()
    {
        //set the players position when initiated 
        transform.position = new Vector3(-8, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.right is exquivalent of writing (1,0,0)
        //This will move the object really fast
       // transform.Translate(Vector3.right * _speed * Time.deltaTime);
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(_horizontalMovement,_verticalMovement,0) *_speed *Time.deltaTime);

    }
}
