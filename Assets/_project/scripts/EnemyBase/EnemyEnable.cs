using System.Collections.Generic;
using UnityEngine;

public class EnemyEnable : MonoBehaviour
{
    [SerializeField] private float _enableDistance; 
    [SerializeField]private List<GameObject> _enemiesList;
    private Transform _playerTransform;
    void Start()
    {
        EnemyHealth[] _enemiesHealthArray = FindObjectsOfType<EnemyHealth>();
        foreach (var enemyHealth in _enemiesHealthArray)
        {
            _enemiesList.Add(enemyHealth.gameObject);  
        }

        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }
    void Update()
    {
        ControlEnemiesEnable();
    }

    private void ControlEnemiesEnable()
    {
        for (int i = 0; i < _enemiesList.Count; i++)
        {
            if (!_enemiesList[i])
            {
                _enemiesList.Remove(_enemiesList[i]);
                return;
            }
            if (Vector3.Distance(_playerTransform.position, _enemiesList[i].transform.position) < _enableDistance)
            {
                if (!_enemiesList[i].activeInHierarchy)
                {
                    _enemiesList[i].SetActive(true);
                }
            }
            else
            {
                if (_enemiesList[i].activeInHierarchy)
                {
                    _enemiesList[i].SetActive(false);
                }
            }

        }
    }
}
