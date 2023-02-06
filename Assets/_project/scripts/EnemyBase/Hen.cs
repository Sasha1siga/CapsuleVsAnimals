using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _velocity = 3;
    [SerializeField] private float _timeToReachSpeed = 1;
    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (_velocity * toPlayer - _rigidbody.velocity) / _timeToReachSpeed;
        _rigidbody.AddForce(force);
    }
}
