using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMover))]
public class AIController : MonoBehaviour
{
    [SerializeField] private List<Transform> _wayPoint;
    [SerializeField] private Transform _selfTransform;

    private CarMover _car;

    private int _currentPoint;

    private void Start()
    {
        _car = GetComponent<CarMover>();
    }

    private void Update()
    {
        Transform current = _wayPoint[_currentPoint];
        Debug.DrawLine(_selfTransform.position, current.position, Color.red);

        Vector3 direction = _selfTransform.position - current.position;
        float angle = Vector3.Dot(direction, -_selfTransform.right);

        Debug.Log(angle);

        if (angle > 0)
            _car.RotateRight();
        else if (angle == 0)
        { }
        else
            _car.RotateLeft();

        if (angle < 0.2f && angle > -0.2f)
            _car.Accelerate();

        if (Vector3.Distance(_selfTransform.position, current.position) < 1f)
        {
            _currentPoint++;
            if (_currentPoint >= _wayPoint.Count - 1)
                _currentPoint = 0;
        }
    }
}
