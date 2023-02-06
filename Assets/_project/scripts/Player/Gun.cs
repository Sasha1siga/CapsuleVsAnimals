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
        _timer += Time.deltaTime;
        if (_timer > _shotPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                _timer = 0f;
                GameObject newBullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
                newBullet.GetComponent<Rigidbody>().velocity = _spawnPoint.forward * _bulletSpeed;
                _shotSound.Play();
                _flash.SetActive(true);
                Invoke("HideFlash", 0.08f);
            }
        }
        
    }
    private void HideFlash()
    {
        _flash.SetActive(false);
    }
}
