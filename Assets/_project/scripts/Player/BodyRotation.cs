using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private float _angleRotation = 45;
    [SerializeField] private float _angleRotationSpeed = 5; 


    void Update()
    {

        if (_pointer.rotation.y > 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -_angleRotation, 0), Time.deltaTime * _angleRotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _angleRotation, 0), Time.deltaTime * _angleRotationSpeed);
        }


        /*if (_pointer.rotation.y > 0)
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0, -_angleRotation, 0), Time.deltaTime * _angleRotationSpeed);
        }
        else
        {
            transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, new Vector3(0, _angleRotation, 0), Time.deltaTime * _angleRotationSpeed);
        }*/
    }
}
