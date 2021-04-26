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
    [SerializeField] private GameObject _statsButton;
    [SerializeField] private GameObject _controlsButton;
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private GameObject _controlsPanel;
    // Start is called before the first frame update
    void Start()
    {
        MoveTitleText();
        MoveTitleImage();
        MoveButtonPanel();
        _statsPanel.SetActive(false);
        _controlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //1240.654   
    }

    public void MoveButtonPanel()
    {
        LeanTween.moveX(_playButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(1f);
        LeanTween.moveX(_statsButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(2f);
        LeanTween.moveX(_controlsButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(3f);
        LeanTween.moveX(_quitButton.GetComponent<RectTransform>(), 744f, 1f).setEase(LeanTweenType.easeOutBack).setDelay(4f);
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

    public void ControlPanelClicked()
    {
        _controlsPanel.SetActive(true);
        LeanTween.moveY(_nameTitle.GetComponent<RectTransform>(), 500f, 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveY(_titleImage.GetComponent<RectTransform>(), 500f, 1f).setEase(LeanTweenType.easeOutBounce);

        LeanTween.moveY(_controlsPanel.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeOutBack);
        if (_statsPanel)
        {
            LeanTween.moveY(_statsPanel.GetComponent<RectTransform>(), -375, 1f).setEase(LeanTweenType.easeOutBack);
            _statsPanel.SetActive(false);
        }

    }

    public void StatsPanelClicked()
    {
        _statsPanel.SetActive(true);
        LeanTween.moveY(_nameTitle.GetComponent<RectTransform>(), 500f, 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveY(_titleImage.GetComponent<RectTransform>(), 500f, 1f).setEase(LeanTweenType.easeOutBounce);
        LeanTween.moveY(_statsPanel.GetComponent<RectTransform>(), 0f, 1f).setEase(LeanTweenType.easeOutBack);
        if (_controlsPanel)
        {
            LeanTween.moveY(_controlsPanel.GetComponent<RectTransform>(), -375, 1f).setEase(LeanTweenType.easeOutBack);
            _controlsPanel.SetActive(false);
        }
    }
}
