using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarMover))]
public class RandomSpeed : MonoBehaviour
{
    private CarMover _car;

    private void Start()
    {
        _car = GetComponent<CarMover>();

        _car.Speed = Random.Range(0.01f, 0.05f);
    }
}
