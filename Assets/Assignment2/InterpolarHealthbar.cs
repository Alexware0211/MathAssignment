using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterpolarHealthbar : MonoBehaviour
{
    private float _maxHealth = 100;
    private float _currentHealth, _currentHealthSlow;
    public Image barFast, barSlow;
    private float amount = 10;
    [SerializeField]private TextMeshProUGUI hpText;

    private void Start() 
    {
        _currentHealth = _maxHealth;
        _currentHealthSlow = _maxHealth;   
    }

    float t = 0;

    private void Update() 
    {
        // interpolating slowHP and currentHP
        if (_currentHealthSlow != _currentHealth)
        {
            _currentHealthSlow = Mathf.Lerp(_currentHealthSlow, _currentHealth, t);
            t += 0.05f * Time.deltaTime;
        }  


        barFast.fillAmount = _currentHealth/_maxHealth; 
        barSlow.fillAmount = _currentHealthSlow/_maxHealth; 
        
        hpText.text = _currentHealth.ToString() + " / " + _maxHealth.ToString();
    }

    public void AddHealth()
    {
        _currentHealth += amount;
        t = 0;
    }

    public void RemoveHealth()
    {
        _currentHealth -= amount;
        t = 0;
    }
}
