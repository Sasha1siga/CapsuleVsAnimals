using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 1f;


    private Transform _playerTransform;
    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Vector3 toPlayer = _playerTransform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toPlayer);
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * _speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }
}
