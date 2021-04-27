using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    //[SerializeField] private Material _material;
    private float _dissolveAmount;
    private bool _isDissolving;
    private float _dissolveSpeed;
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

        if (Input.GetKeyDown(KeyCode.T))
        {
            StartDissolve(1f);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            StopDissolve(1f);
        }
    }

    public void StartDissolve(float speed)
    {
        _isDissolving = true;
        this._dissolveSpeed = speed;
        Debug.Log("Dissolving shield");
    }

    public void StopDissolve(float speed)
    {
        _isDissolving = false;
        this._dissolveSpeed = speed;
        Debug.Log("Enabling shield");
    }

    

}
