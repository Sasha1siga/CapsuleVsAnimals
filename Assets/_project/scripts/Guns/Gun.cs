using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _bulletSpeed = 10f;
    [SerializeField] private float _shotPeriod = 0.2f;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject _flash;

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
    }
    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void AddBullets(int numberOfBullet)
    {
    }
}
