using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField]private List<ActivateByDistance> _enemiesList;
    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void Update()
    {
        for (int i = 0; i < _enemiesList.Count; i++)
        {
            _enemiesList[i].CheckDistance(_playerTransform.position);
        }
    }

    
    public void AddObjectToActivateList(ActivateByDistance activateByDistance)
    {
        _enemiesList.Add(activateByDistance);
    }
    public void RemoveObjectFromActivateList(ActivateByDistance activateByDistance)
    {
        _enemiesList.Remove(activateByDistance);
    }
}
