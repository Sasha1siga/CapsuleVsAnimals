using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _bulletTimeToDestroy = 7f;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;
    [SerializeField] private int _damageValue;

    private float _timer;
    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                Shot();
            }
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(_bulletPrefab, _spawnPoint.position, _bulletPrefab.transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;
        Bullet bullet = newBullet.GetComponent<Bullet>();
        bullet.DamageValue = _damageValue;
        bullet.TimeToDestroy = _bulletTimeToDestroy;
        _shotSound.Play();
        _flash.SetActive(true);
        Invoke("HideFlash", 0.08f);
    }    
    private void HideFlash()
    {
        _flash.SetActive(false);
    }
    public virtual void Activate()
    {
        gameObject.SetActive(true);
        Debug.Log("Activate");
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
        Debug.Log("Deactivate");
    }
    public virtual void AddBullets(int numberOfBullet)
    {
    }
}
