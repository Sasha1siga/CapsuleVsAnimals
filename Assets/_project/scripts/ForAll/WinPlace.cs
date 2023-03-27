using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlace : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth _playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (_playerHealth)
        {
            _gameController.Win();
        }
    }
}
