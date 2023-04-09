using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody Rigidbody { get;set; }

    [SerializeField] private Collider _playerCollider;
    
    private Collider _collider;
    private FixedJoint _fixedJoint;
    private RopeGun _ropeGun;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        Physics.IgnoreCollision(_collider, _playerCollider);
        _ropeGun = FindObjectOfType<RopeGun>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            _ropeGun.CreateSpring();
        }
    }
    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
