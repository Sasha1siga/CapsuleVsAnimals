using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform _mark;
    [SerializeField] private Text _teleportHint;

    
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.name);
            Debug.Log(other.transform.GetComponent<PlayerMove>());
        if (other.attachedRigidbody.transform.GetComponent<PlayerMove>())
        {
            if (Input.GetKey(KeyCode.E))
                Teleportation(other.attachedRigidbody.transform, _mark.position);
            _teleportHint.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _teleportHint.enabled = false;
    }
    

    private void Teleportation(Transform objectTransform, Vector3 mark)
    {
        objectTransform.position = mark + Vector3.up * (objectTransform.localScale.y / 2);
    }
}
