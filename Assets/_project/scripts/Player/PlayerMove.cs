using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Transform _capsuleTransform;
    [SerializeField] private Transform _pointer;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _playerRigidbody.AddForce(0, _jumpSpeed, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || !_grounded)
        {
            _capsuleTransform.localScale = Vector3.Lerp(_capsuleTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            _capsuleTransform.localScale = Vector3.Lerp(_capsuleTransform.localScale, Vector3.one, Time.deltaTime * 15f); ;
        }

        
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;
        if (!_grounded)
        {
            speedMultiplier = 0.2f;
            if (_playerRigidbody.velocity.x > _maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }
            if (_playerRigidbody.velocity.x < -_maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }
        
        _playerRigidbody.AddForce(Input.GetAxis("Horizontal") * _moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
        if (_grounded)
        {
            _playerRigidbody.AddForce(-_playerRigidbody.velocity.x * _friction, 0, 0, ForceMode.VelocityChange);
        }

        

       
    }

   
    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                _grounded = true;
            }
        }
        
        
    }
    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
