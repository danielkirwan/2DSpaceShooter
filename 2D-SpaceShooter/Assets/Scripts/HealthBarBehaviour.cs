using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider _slider;
    public Color _low;
    public Color _high;
    public Vector3 offset;

    public Image _healthImage;
    float _lerpSpeed = 3f;

    private void Start()
    {
        //_healthImage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        _slider.gameObject.SetActive(health < maxHealth);
        _slider.value = health;
        _slider.maxValue = maxHealth;

        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, _slider.normalizedValue);

        //_lerpSpeed = 3f * Time.deltaTime;
        //_healthImage.fillAmount = health / maxHealth;
        //float testAmount = health / maxHealth;
        //float LerpFill = Mathf.Lerp(_healthImage.fillAmount, testAmount, 1f);
        //Debug.Log("Fill is now " + LerpFill);
        //_healthImage.fillAmount = Mathf.Lerp(_healthImage.fillAmount, health/maxHealth, _lerpSpeed);
        //_healthImage.fillAmount = LerpFill;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        //_lerpSpeed = 100f * Time.deltaTime;
        //_healthImage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
