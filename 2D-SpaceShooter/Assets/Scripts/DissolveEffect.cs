using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    //[SerializeField] private Material _material;
    private float _dissolveAmount;
    private bool _isDissolving;
    private float _dissolveSpeed;
    private float _hitAmount;
    private float _nextDissolveAmount = 1f;

    private bool _shieldHit = false;
    //Allows access to the renderer material instance.
    [SerializeField] private Renderer _material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDissolving)
        {
            _dissolveAmount = Mathf.Clamp01(_dissolveAmount + _dissolveSpeed * Time.deltaTime);
            _material.material.SetFloat("_dissolveAmount", _dissolveAmount);
        }
        else
        {
            _dissolveAmount = Mathf.Clamp01(_dissolveAmount - _dissolveSpeed * Time.deltaTime);
            _material.material.SetFloat("_dissolveAmount", _dissolveAmount);
        }

        if (_shieldHit)
        {
            //_dissolveAmount = (_hitAmount + _dissolveSpeed * Time.deltaTime);
            _dissolveAmount = Mathf.Clamp(_dissolveAmount + _dissolveSpeed * Time.deltaTime, _hitAmount, _nextDissolveAmount);
            //_dissolveAmount = Mathf.Clamp01(_hitAmount + _dissolveSpeed * Time.deltaTime);
            //Debug.Log("Dissolve amount is " + _dissolveAmount);
            _material.material.SetFloat("_dissolveAmount", _dissolveAmount);
        }
        

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartDissolve(1f);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            StopDissolve(1f);
        }
    }

    public void ShieldHit(float hitAmount, float speed)
    {
        _shieldHit = true;
        _hitAmount = hitAmount;
        _dissolveSpeed = speed;

        if(_hitAmount == 0.4f)
        {
            _nextDissolveAmount = 0.6f;
        }else if (_hitAmount == 0.6f)
        {
            _dissolveAmount = 1f;
            StartDissolve(_dissolveSpeed);
        }

    }

    public void StartDissolve(float speed)
    {
        _isDissolving = true;
        this._dissolveSpeed = speed;
    }

    public void StopDissolve(float speed)
    {
        _isDissolving = false;
        _shieldHit = false;
        this._dissolveSpeed = speed;
    }

    public void ChangeShieldColour(int colour)
    {
        if(colour == 3)
        {
            _material.material.color = Color.cyan;
        }
        else if(colour == 2)
        {
            _material.material.color = Color.green;
        }
        else if(colour == 1)
        {
            _material.material.color = Color.red;
        }
    }

}
