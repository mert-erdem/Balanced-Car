using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    Rigidbody2D physics;
    [SerializeField] private WheelJoint2D _wheelBack, _wheelFront;
    [Range(0, 5000)] public int _speed;
    private float _horizontalMovement, _fuel=100;

    void Start()
    {
        physics = transform.GetComponent<Rigidbody2D>();

        _wheelFront.useMotor = false;
    }

    void Update()
    {
        _horizontalMovement = -Input.GetAxisRaw("Horizontal")*_speed;

        if (Input.GetKey(KeyCode.Space))
            StopTheCar();
    }

    private void FixedUpdate() => Movement();

    private void Movement()
    {
        if (_horizontalMovement == 0)
            _wheelBack.useMotor = false;       
        else
        {
            _wheelBack.useMotor = true;

            var motor = new JointMotor2D { motorSpeed = _horizontalMovement, maxMotorTorque = _wheelBack.motor.maxMotorTorque };
            _wheelBack.motor = motor;

            _fuel -= 0.1f;
            Debug.Log(_fuel);
        }
    }

    private void StopTheCar()
    {
        physics.velocity = Vector2.zero;
    }
}
