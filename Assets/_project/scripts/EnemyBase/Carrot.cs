using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        Transform playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        rigidbody.velocity = toPlayer * _speed;
    }
    


}
