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
    [Space]
    [Header("Images")]
    [SerializeField] private Sprite[] _lives;
    [SerializeField] private Image _livesImage;
    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _restartLevel.gameObject.SetActive(false);
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
        }
    }

    public void UpdateScore(int updateScore)
    {
        _scoreText.text = "Score: " + updateScore;
    }

    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _lives[currentLives];
    }

    public void GameOverText()
    {
        _gameOverText.gameObject.SetActive(true);
        _restartLevel.gameObject.SetActive(true);
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
