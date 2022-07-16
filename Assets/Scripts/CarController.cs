using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMover))]
public class CarController : MonoBehaviour
{
    private CarMover _car;

    private void Start()
    {
        _car = GetComponent<CarMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            _car.Accelerate();

        if (Input.GetKey(KeyCode.A))
            _car.RotateLeft();

        if (Input.GetKey(KeyCode.D))
            _car.RotateRight();

    }
}
