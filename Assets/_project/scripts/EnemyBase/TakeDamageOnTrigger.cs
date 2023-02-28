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
            Bullet bullet = bulletRigidbody.GetComponent<Bullet>();
            if (bullet)
            {
                _enemyHealth.TakeDamage(bullet.DamageValue);
                bullet.Die();

            }
        }
        if (_dieOnAnyCollision && !other.isTrigger)
        {
            _enemyHealth.TakeDamage(100000000);
        }

    }
}
