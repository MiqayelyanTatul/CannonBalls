using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] int _speed;
    [SerializeField] float _friction;
    [SerializeField] float _lerpSpeed;
    private float _xDegrees;
    private float _yDegrees;
    private Quaternion _fromRotation;
    private Quaternion _toRotation;
    private Camera _camera;
    private const string Cannon = nameof(Cannon);
    [SerializeField] private GameObject _cannonBall;
    private Rigidbody _cannonBallRB;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private float _firePower;
    private int _powerMultiplier = 200;
    private void Start()
    {
        _camera = Camera.main;
        _firePower *= _powerMultiplier;
    }
    private void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == Cannon)
        {
            if (Input.GetMouseButton(0))
            {
                _xDegrees -= Input.GetAxis("Mouse Y") * _speed * _friction;
                _yDegrees += Input.GetAxis("Mouse X") * _speed * _friction;
                _fromRotation = transform.rotation;
                _toRotation = Quaternion.Euler(_xDegrees, _yDegrees, 0);
                transform.rotation = Quaternion.Lerp(_fromRotation, _toRotation, Time.deltaTime * _lerpSpeed);
            }
        }
        if (Input.GetMouseButtonDown(1) && Points.Instance.BallCount > 0)
        {
            FireConnon();
        }
    }

    public void FireConnon()
    {
        GameObject _cannonBallCopy = Instantiate(_cannonBall, _shotPosition.position, transform.rotation) as GameObject;
        _cannonBallRB = _cannonBallCopy.GetComponent<Rigidbody>();
        _cannonBallRB.AddForce(transform.forward * _firePower);
        Instantiate(_explosion, _shotPosition.transform.position, _shotPosition.rotation);
    }
}