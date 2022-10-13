using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Points : MonoBehaviour
{
    public static Points Instance { get; private set; }
    private const string _target = "Target";
    private int _score = 0;
    public int BallCount;
    [SerializeField] private Text _ballCountText;
    [SerializeField] private Text _text;
    private const string _minusBall = "MinusBall";
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _target)
        {
            _score += 10;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        _text.text = _score.ToString();
        _ballCountText.text = BallCount.ToString();
        if (Input.GetMouseButtonDown(1) && Points.Instance.BallCount > 0)
        {
            Invoke(_minusBall, 0.1f);
        }
        if (_score == 270)
        {
            Application.LoadLevel(2);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void MinusBall()
    {
        BallCount--;
    }
}
