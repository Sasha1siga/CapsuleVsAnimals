using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        transform.rotation = Quaternion.identity;

        Transform playerTransform = FindObjectOfType<PlayerHealth>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = toPlayer * _speed;
    }
    


}
