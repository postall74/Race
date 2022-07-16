using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Transform))]
public class CarMover : MonoBehaviour
{
    [Header("Car Info")]
    [SerializeField] private float _speed = 0.01f;
    [SerializeField] private float _rotationForce = 0.5f;
    [SerializeField] private float _decelerationForce = 0.99f;

    [Header("Tilemap Info")]
    [SerializeField] private Tilemap _currentTile;
    [SerializeField] private List<TileBase> _notRoadTiles;

    private Transform _selfTransform;
    private Vector3 _accelerationForce;
    private bool _isAccelerated;

    public float Speed 
    { 
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }

    private void Start()
    {
        _selfTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if (!_isAccelerated)
            _accelerationForce = Vector3.Lerp(_accelerationForce, Vector3.zero, Time.deltaTime);


        foreach (var tile in _notRoadTiles)
        {
            if (tile == _currentTile.GetTile(new Vector3Int((int)_selfTransform.position.x, (int)_selfTransform.position.y, (int)_selfTransform.position.z)))
                _accelerationForce *= _decelerationForce;
        }

        _selfTransform.position += _accelerationForce;
        _isAccelerated = false;
    }

    public void Accelerate()
    {
        _accelerationForce += (_selfTransform.up * Time.deltaTime) * _speed;
        _isAccelerated = true;
    }

    public void RotateRight()
    {
        _selfTransform.Rotate(0, 0, -_rotationForce);
    }

    public void RotateLeft()
    {
        _selfTransform.Rotate(0, 0, _rotationForce);
    }


    public float GetForce()
    {
        return _accelerationForce.magnitude;
    }
}
