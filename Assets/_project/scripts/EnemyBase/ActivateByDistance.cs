#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float _distanceToActivate = 20f;


    private Activator _activator;
    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.AddObjectToActivateList(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (gameObject.activeInHierarchy)
        {
            if (distance > _distanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < _distanceToActivate)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        gameObject.SetActive(true);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    private void OnDestroy()
    {
        _activator.RemoveObjectFromActivateList(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.grey;
        Handles.DrawWireDisc(transform.position, Vector3.forward, _distanceToActivate);
    }
#endif
}
