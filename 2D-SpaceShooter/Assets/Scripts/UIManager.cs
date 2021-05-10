using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Text objects")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartLevel;
    [SerializeField] private Text _backToMainMenu;
    [SerializeField] private Text _pauseText;
    [Space]
    [Header("Images")]
    [SerializeField] private Sprite[] _lives;
    [SerializeField] private Image _livesImage;
    [SerializeField] private Sprite[] _shield;
    [SerializeField] private Image _shieldImage;
    [SerializeField] private Sprite[] _bullets;
    [SerializeField] private Image _bulletImage;
    [Space]
    [SerializeField] private GameObject _shieldImageObject;
    [Space]
    [SerializeField] private Button _resumeButton;

    private bool _isGameOver = false;
    private bool _isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _restartLevel.gameObject.SetActive(false);
        _livesImage.gameObject.SetActive(false);
        _shieldImage.gameObject.SetActive(false);
        _resumeButton.gameObject.SetActive(false);
        _pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
            }
        }

        if (_isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        
    }

    public void ResumePlay()
    {
        _isPaused = false;
        _resumeButton.gameObject.SetActive(false);
        _pauseText.gameObject.SetActive(false);
    }

    void PauseGame()
    {
        _isPaused = true;
        _resumeButton.gameObject.SetActive(true);
        _pauseText.gameObject.SetActive(true);
    }


    public void UpdateBullets(int bullets)
    {
        _bulletImage.sprite = _bullets[bullets];
    }

    public void UpdateScore(int updateScore)
    {
        _scoreText.text = "Score: " + updateScore;
    }

    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _lives[currentLives];
    }

    public void UpdateShield(int currentShieldHits)
    {
        _shieldImage.sprite = _shield[currentShieldHits];
    }

    public void ActivateShieldImage()
    {
        _shieldImageObject.SetActive(true);
    }

    public void DeactivateShieldImage()
    {
        _shieldImageObject.SetActive(false);
    }

    public void GameOverText()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartLevel.gameObject.SetActive(true);
        _backToMainMenu.gameObject.SetActive(true);
        _isGameOver = true;
        StartCoroutine(GameOverTextRoutine());
    }

    IEnumerator GameOverTextRoutine()
    {
        while (_isGameOver)
        {
            yield return new WaitForSeconds(1);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(true);
        }
    }

}
