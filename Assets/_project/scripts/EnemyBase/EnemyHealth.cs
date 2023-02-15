using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    [SerializeField] private UnityEvent _eventOnTakeDamage;

    public void TakeDamage(int damageValue)
    {
        _health -= damageValue;
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            _eventOnTakeDamage.Invoke();
            Debug.Log("Damage");
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
