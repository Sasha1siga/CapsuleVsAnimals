using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] int _healthValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            PlayerHealth playerHealth = other.attachedRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.AddHealth(_healthValue);
                Die();
            }

        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }    
}
