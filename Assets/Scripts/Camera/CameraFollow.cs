using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _target;
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }
    private void Start()
    {
        _target = FindObjectOfType<StateMachine>().transform;
    }

    private void LateUpdate()
    {
        transform.position = _target.position + new Vector3(0, 0, -10);
    }

}
