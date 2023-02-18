using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StapActivateMeshRenderer : MonoBehaviour
{
    [SerializeField] private bool _changeForever;
    private Renderer _objectRenderer;
    private void Start()
    {
        _objectRenderer = GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerHealth _playerHealth = collision.transform.GetComponent<PlayerHealth>();
        if (_playerHealth)
        {
            _objectRenderer.enabled = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!_changeForever)
        {
            PlayerHealth _playerHealth = collision.transform.GetComponent<PlayerHealth>();
            if (_playerHealth)
            {
                _objectRenderer.enabled = false;
            }
        }
       
    }
}
