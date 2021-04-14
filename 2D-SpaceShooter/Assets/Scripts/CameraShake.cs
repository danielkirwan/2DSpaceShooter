using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Vector2 _cameraShake;
    Transform _cameraTrans;
    Vector3 _initialPos;

    // Start is called before the first frame update
    void Start()
    {
        _cameraTrans = Camera.main.transform;
        _initialPos = _cameraTrans.position;
    }

    public void CameraShakeStart()
    {
        HorizontalCameraShake();
    }

    void HorizontalCameraShake()
    {
        LeanTween.moveX(_cameraTrans.gameObject, _cameraShake.x, 0.01f).setOnComplete(VerticalCameraShake);
    }

    void VerticalCameraShake()
    {
        LeanTween.moveY(_cameraTrans.gameObject, _cameraShake.y, 0.05f).setOnComplete(DefaultCameraShake);
    }

    void DefaultCameraShake()
    {
        LeanTween.move(_cameraTrans.gameObject, _initialPos, 0.01f);
    }
}
