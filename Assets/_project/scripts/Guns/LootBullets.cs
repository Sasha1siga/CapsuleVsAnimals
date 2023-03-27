using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex;
    [SerializeField] int _numberOfBullet = 30;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerArmory playerArmory = other.attachedRigidbody.GetComponent<PlayerArmory>();
            if (playerArmory)
            {
                playerArmory.AddBullets(_gunIndex, _numberOfBullet);
                Die();
            }

        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
