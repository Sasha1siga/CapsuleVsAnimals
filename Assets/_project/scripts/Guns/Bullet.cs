using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    
    
    private float _timeToDestroy  = 7f;
    private int _damageValue;
    public int DamageValue
    {
        get
        {
            return _damageValue;
        }
        set
        {
            _damageValue = value;
        }
    }
    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }
    public void Die()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public float TimeToDestroy
    {
        get
        {
            return _timeToDestroy;
        }
        set
        {
            _timeToDestroy = value;
        }
    }


}
