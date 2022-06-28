using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;

    private Rigidbody2D _rigidbody;
    private float _horizontalAxis = 0f;
    private float _verticalAxis = 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _verticalAxis = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (_horizontalAxis != 0f || _verticalAxis != 0f)
        {
            TranslatePosition();
        }
    }

    private void TranslatePosition()
    {
        var target = transform.position + new Vector3(_horizontalAxis, _verticalAxis) * _speed;
        _rigidbody.MovePosition(target);
    }
}
