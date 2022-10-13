using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    [SerializeField] private Vector3 _upRecoil;
    private const string _addRecoil = "AddRecoil";
    private const string _stopRecoil = "StopRecoil";


    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Points.Instance.BallCount > 0)
        {
           Invoke(_addRecoil,0.1f);
           Invoke(_stopRecoil, 0.15f);
        }
    }

    private void AddRecoil()
    {
        transform.position += _upRecoil;
    }
    private void StopRecoil()
    {
        transform.position -= _upRecoil;
    }
}
