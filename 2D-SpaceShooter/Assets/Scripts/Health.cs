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

    public Image _healthImage;
    // Start is called before the first frame update
    void Start()
    {
        _healthImage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }

    public void SetHealth(float health, float maxHealth)
    {
        _healthImage.fillAmount = health / maxHealth;
        //_healthImage.color = Color.Lerp(_low, _high, 1f);
        float _newHealth = health / maxHealth;
        if(_newHealth > .75f)
        {
            _healthImage.color = new Color(_high.r,_high.g, _high.g);
            //_healthImage.color = Color.Lerp(_high, _high, 1f);
        }
        else if(_newHealth >=.4f && _newHealth <= .75f)
        {
             _healthImage.color = new Color(_mid.r, _mid.g, _mid.g);
            //_healthImage.color = Color.Lerp(_mid, _high, 1f);
        }
        else if(_newHealth < .4f)
        {
            _healthImage.color = new Color(_low.r, _low.g, _low.g);
            //_healthImage.color = Color.Lerp(_low, _high, 1f);
        }

        //_healthImage.GetComponentInChildren<Image>().color = Color.Lerp(_low, _high, 1f);
    }



    // Update is called once per frame
    void Update()
    {
        _healthImage.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
