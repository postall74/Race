using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _selfTransform;
    [SerializeField] private float _speedCameraMoving = 0.03f;


    private void LateUpdate()
    {
        _selfTransform.position = Vector3.Lerp(_selfTransform.position, _target.position + new Vector3(0, 0, -10), _speedCameraMoving);
    }
}
