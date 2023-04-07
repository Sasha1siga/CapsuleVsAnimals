using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawn;
    

    void Update()
    {
        if ( Input.GetMouseButton(2) )
        {
            Shot();
        }
    }
    private void Shot()
    {
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;
    }
}
