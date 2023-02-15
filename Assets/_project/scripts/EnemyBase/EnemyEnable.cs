using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnable : MonoBehaviour
{
    [SerializeField] private float _enableDistance; 

    [SerializeField]private List<GameObject> _enemyList;
    private Transform _playerTransform;
    void Start()
    {
        EnemyHealth[] _enemiesHealthArray = FindObjectsOfType<EnemyHealth>();
        foreach (var item in _enemiesHealthArray)
        {
            _enemyList.Add(item.gameObject);  
        }

        _playerTransform = FindObjectOfType<PlayerHealth>().transform;
    }
    void Update()
    {
        for (int i = 0; i < _enemyList.Count; i++)
        {
            if (!_enemyList[i])
            {
                _enemyList.Remove(_enemyList[i]);
                return;
            }
            if (Vector3.Distance(_playerTransform.position, _enemyList[i].transform.position) < _enableDistance)
            {
                if (!_enemyList[i].activeInHierarchy)
                {
                    _enemyList[i].SetActive(true);
                }
            }
            else
            {
                if (_enemyList[i].activeInHierarchy)
                {
                    _enemyList[i].SetActive(false);
                }
            }
            
        }
    }
}
