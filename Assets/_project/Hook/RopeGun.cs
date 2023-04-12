using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disabled, 
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _spawn;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private SpringJoint _springJoint;
    [SerializeField] private float _spring = 100f;
    [SerializeField] private float _damper = 5f;

    [SerializeField] private RopeState _currentRopeState;
    [SerializeField] private RopeRenderer _ropeRenderer;
    private float _length;
    private PlayerMove _playerMove;
    private void Start()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if (Input.GetMouseButton(2))
        {
            Shot();
        }
        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            if (distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active)
            {
                if (!_playerMove.Grounded)
                {
                    _playerMove.Jump();
                }
            }
            DestroySpring();
        }
        if (_currentRopeState == RopeState.Active || _currentRopeState == RopeState.Fly)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _length);
        }
    }
    private void Shot()
    {
        _length = 1f;
        if (_springJoint)
            Destroy(_springJoint);

        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;

        _currentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = _spring;
            _springJoint.damper = _damper;

            _length = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            _springJoint.maxDistance = _length;

            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            _currentRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
