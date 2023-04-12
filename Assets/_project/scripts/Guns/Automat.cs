using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [Header("Automat")]
    [SerializeField] private int _numberOfBullets;
    [SerializeField] private Text _bulletsText;
    [SerializeField] private PlayerArmory _playerArmory;
    [SerializeField] private int _ginIndex = 2;

    public override void Shot()
    {
        base.Shot();
        _numberOfBullets -= 1;
        UpdateText();
        if (_numberOfBullets == 0)
        {
           _playerArmory.TakeGunByIndex(0);
        }
    }

    public override void Activate()
    {
        base.Activate();
        _bulletsText.enabled = true;
        UpdateText();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        _bulletsText.enabled = false;
    }
    private void UpdateText()
    {
        _bulletsText.text = "Пули:" + _numberOfBullets.ToString();
    }

    public override void AddBullets(int numberOfBullet)
    {
        _numberOfBullets += numberOfBullet;
        UpdateText();
        _playerArmory.TakeGunByIndex(_ginIndex);
        base.AddBullets(numberOfBullet);
    }
}
