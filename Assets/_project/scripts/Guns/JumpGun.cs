using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private float _maxCharge;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private Gun _pistol;
    [SerializeField] private ChargeIcon _chargeIcon;
 


    private float currentCharge;
    private bool isCharged;
   
    void Update()
    {
        
        if (isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRigidbody.AddForce(-_spawn.forward * _jumpSpeed, ForceMode.VelocityChange);
                _pistol.Shot();
                isCharged = false;
                currentCharge = 0;

                _chargeIcon.StartCharge();
            }
        }
        else
        {
            currentCharge += Time.deltaTime;
            _chargeIcon.SetChargeValue(currentCharge, _maxCharge);
            if (currentCharge >= _maxCharge)
            {
                isCharged = true;
                _chargeIcon.StopCharge();
            }
                
        }

        
    }
}
