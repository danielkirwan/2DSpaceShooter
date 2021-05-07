using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Color _low;
    public Color _high;
    public Color _mid;
    public Vector3 offset;
    //public float number = 6f;
    private float maxHealth;
    private float lerptimer = 0f;
    private float percentComplete;

    public Image _healthImage;
    // Start is called before the first frame update
    void Start()
    {
        MoveImage();
    }

    public void SetHealth(float health, float maxHealth)
    {
        this.maxHealth = maxHealth;
        float fillAmount = _healthImage.fillAmount;
        float newFillAmount = health / maxHealth;
        //_healthImage.fillAmount = health / maxHealth;
        //_healthImage.color = Color.Lerp(_low, _high, 1f);

        float _newHealth = health / maxHealth;

        if (_newHealth == 1f)
        {
            _healthImage.color = Color.green;
            //_healthImage.fillAmount = Mathf.Lerp(fillAmount, newFillAmount, percentComplete);
            _healthImage.fillAmount = _newHealth;
        }
        else if(_newHealth > .75f && _newHealth <1f)
        {
            _healthImage.color = new Color(_high.r,_high.g, _high.g, _high.a);
            //_healthImage.color = Color.Lerp(_high, _high, 1f);
            //_healthImage.fillAmount = Mathf.Lerp(fillAmount, newFillAmount, percentComplete);
            _healthImage.fillAmount = _newHealth;
        }
        else if(_newHealth >=.4f && _newHealth <= .75f)
        {
             _healthImage.color = new Color(_mid.r, _mid.g, _mid.g, _mid.a);
            //_healthImage.color = Color.Lerp(_mid, _high, 1f);
            // _healthImage.fillAmount = Mathf.Lerp(fillAmount, newFillAmount, percentComplete);
            _healthImage.fillAmount = _newHealth;
        }
        else if(_newHealth < .4f)
        {
            _healthImage.color = new Color(_low.r, _low.g, _low.g,_low.a);
            //_healthImage.color = Color.Lerp(_low, _high, 1f);
            //_healthImage.fillAmount = Mathf.Lerp(fillAmount, newFillAmount, percentComplete);
            _healthImage.fillAmount = _newHealth;
        }

        //_healthImage.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, 1f);
    }

    void MoveImage()
    {
        _healthImage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    // Update is called once per frame
    void Update()
    {
        //lerptimer += Time.deltaTime;
        //percentComplete = lerptimer / number;
        MoveImage();
    }
}
