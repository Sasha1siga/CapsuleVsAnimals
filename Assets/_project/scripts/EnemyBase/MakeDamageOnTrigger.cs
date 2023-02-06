using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] int _damageValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody playerRigidbody = other.attachedRigidbody;
        if (playerRigidbody)
        {
            PlayerHealth playerHealth = playerRigidbody.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(_damageValue);
            }
        }
    }
}
