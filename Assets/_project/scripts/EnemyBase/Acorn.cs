using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxRottationSpeed;
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(_velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(
            Random.Range(-_maxRottationSpeed, _maxRottationSpeed), 
            Random.Range(-_maxRottationSpeed, _maxRottationSpeed), 
            Random.Range(-_maxRottationSpeed, _maxRottationSpeed)
            );
    }
}

