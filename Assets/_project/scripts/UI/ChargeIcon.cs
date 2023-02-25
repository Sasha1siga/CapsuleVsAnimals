using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _foreground;
    [SerializeField] private Image _background;
    [SerializeField] private Text _timer;


    public void StartCharge()
    {
        _background.color = new Color(1, 1, 1, 0.2f);
        _foreground.enabled = true;
        _timer.enabled = true;
    }
    public void StopCharge()
    {
        _background.color = new Color(1, 1, 1, 1);
        _foreground.enabled = false;
        _timer.enabled = false;

    }
    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreground.fillAmount = currentCharge / maxCharge;
        _timer.text = Mathf.Ceil(maxCharge-currentCharge).ToString();
    }
} 
