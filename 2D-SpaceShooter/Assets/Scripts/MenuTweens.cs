using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTweens : MonoBehaviour
{
    [SerializeField] private GameObject _titleTextObject;
    // Start is called before the first frame update
    void Start()
    {
        MoveTitleText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTitleText()
    {
        LeanTween.moveX(_titleTextObject.GetComponent<RectTransform>(), 0f, 2f).setEase(LeanTweenType.easeOutBounce).setDelay(1f);
    }

}
