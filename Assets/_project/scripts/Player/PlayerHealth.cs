using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    [SerializeField] private int _maxHealth = 8;
    [SerializeField] private AudioSource _addHealthSound;
    [SerializeField] private HealthUI _healthUI;

    [SerializeField] private UnityEvent _eventOnTakeDamage;
    //[SerializeField] private DamageScreen _damageScreen;
    //[SerializeField] private AudioSource _takeDamageSound;
    //[SerializeField] private Blink _blink;

    private void Start()
    {
        _healthUI.Setup(_maxHealth);
        _healthUI.DesplayHealth(_health);
    }
    private bool _invulnerable = false;
    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            Invoke("StopInvulnerable", 1f);
            _invulnerable = true;
            _healthUI.DesplayHealth(_health);
            _eventOnTakeDamage.Invoke();
            //_takeDamageSound.Play();
            /*_damageScreen.StartEffect();
            _blink.StartBlink();*/
        }
    }
    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
    public void AddHealth(int healthValue)
    {
        _health += healthValue;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
        _addHealthSound.Play();
        _healthUI.DesplayHealth(_health);
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
