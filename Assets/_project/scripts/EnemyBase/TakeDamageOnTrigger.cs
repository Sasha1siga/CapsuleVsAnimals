using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody bulletRigidbody = other.attachedRigidbody;
        if (bulletRigidbody)
        {
            if (bulletRigidbody.GetComponent<Bullet>())
            {
                _enemyHealth.TakeDamage(1);
            }
        }
        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(100000000);
        }

    }
}
