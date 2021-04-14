using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTweens : MonoBehaviour
{
    [SerializeField] private GameObject _titleImage;
    [SerializeField] private GameObject _nameTitle;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _quitButton;
    // Start is called before the first frame update
    void Start()
    {
        MoveTitleText();
        MoveTitleImage();
        MoveButtonPanel();
    }

    // Update is called once per frame
    void Update()
    {
        //1240.654   
    }

    public void MoveButtonPanel()
    {
        LeanTween.moveX(_playButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(1f);
        LeanTween.moveX(_quitButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(2f);
    }

    public void MoveTitleText()
    {
        LeanTween.moveX(_nameTitle.GetComponent<RectTransform>(), 0f, 3f).setEase(LeanTweenType.easeOutBounce).setDelay(1f);
    }

    public void MoveTitleImage()
    {
        LeanTween.moveX(_titleImage.GetComponent<RectTransform>(), 0f, 3f).setEase(LeanTweenType.easeOutBounce).setDelay(1f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
