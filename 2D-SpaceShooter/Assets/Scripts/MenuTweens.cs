using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTweens : MonoBehaviour
{
    [SerializeField] private GameObject _titleImage;
    [SerializeField] private GameObject _nameTitle;
    // Start is called before the first frame update
    void Start()
    {
        MoveTitleText();
        MoveTitleImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveTitleText()
    {
        LeanTween.moveX(_nameTitle.GetComponent<RectTransform>(), 0f, 3f).setEase(LeanTweenType.easeOutBounce).setDelay(1f);
    }

    public void MoveTitleImage()
    {
        LeanTween.moveX(_titleImage.GetComponent<RectTransform>(), 0f, 3f).setEase(LeanTweenType.easeOutBounce).setDelay(1f);

    }

}
