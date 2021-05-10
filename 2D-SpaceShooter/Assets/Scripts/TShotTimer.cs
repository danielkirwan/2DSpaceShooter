using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TShotTimer : MonoBehaviour
{
    public Vector3 _offset;
    public Animator _anim;
    public GameObject _textContainer;
    public GameObject _playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        MoveTextTimer();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTextTimer();
    }

    void MoveTextTimer()
    {
        _textContainer.transform.position = Camera.main.WorldToScreenPoint(_playerPosition.transform.position + _offset);
    }

    public void ActivateAnimation()
    {
        _anim.SetTrigger("tShotActive");
    }

    public void DeactivateAnimation()
    {
        _anim.SetTrigger("tShotActive");
    }

}
