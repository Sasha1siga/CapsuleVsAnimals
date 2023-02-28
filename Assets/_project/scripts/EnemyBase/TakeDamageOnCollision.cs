using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Bullet bullet = collision.rigidbody.GetComponent<Bullet>();
            if (bullet)
            {
                _enemyHealth.TakeDamage(bullet.DamageValue);

            }
        }
        if (_dieOnAnyCollision)
        {
            _enemyHealth.TakeDamage(100000000);
        }
        
    }
}
