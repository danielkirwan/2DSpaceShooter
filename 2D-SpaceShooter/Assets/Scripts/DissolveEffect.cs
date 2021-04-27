using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    [SerializeField] private Material _material;
    private float _dissolveAmount;
    private bool _isDissolving;
    private float _dissolveSpeed;
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
            _material.SetFloat("_dissolveAmount", _dissolveAmount);
        }
        else
        {
            _dissolveAmount = Mathf.Clamp01(_dissolveAmount - _dissolveSpeed * Time.deltaTime);
            _material.SetFloat("_dissolveAmount", _dissolveAmount);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            _isDissolving = true;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            _isDissolving = false;
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
        this._dissolveSpeed = speed;
    }



}
