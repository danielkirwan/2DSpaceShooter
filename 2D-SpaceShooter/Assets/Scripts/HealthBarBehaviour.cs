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


    public void SetHealth(float health, float maxHealth)
    {
        _slider.gameObject.SetActive(health < maxHealth);
        _slider.value = health;
        _slider.maxValue = maxHealth;

        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, _slider.normalizedValue);
    }

    // Update is called once per frame
    void Update()
    {
        _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
