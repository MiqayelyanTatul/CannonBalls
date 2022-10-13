using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _clip;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && Points.Instance.BallCount > 0)
        {
            _source.PlayOneShot(_clip);
        }
    }
}
