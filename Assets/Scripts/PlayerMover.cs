using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeedSide = 5;
    [SerializeField] private float _moveSpeedForward = 1;
    [SerializeField] private PlaneMover _planeMover;
    [SerializeField] private float _range;
    private Input _playerInput;
    public float DirectionSide { get; private set; }
    private Rigidbody _body;
    private float _movementSpeed = 10;

    private float _moveSpeed;

    private void Start()
    {
        _moveSpeed = _moveSpeedForward + _planeMover.MoveSpeed;
    }

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
        _playerInput = new Input { };
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        DirectionSide = _playerInput.Player.Move.ReadValue<float>();
       // _tray.RotationTray(DirectionSide);
       // _tray.ResetRotation(DirectionSide);

        if (DirectionSide < 0 && (transform.position.x <= -_range))
        {
            
            DirectionSide = 0;
            
            SetPositionX(-_range);
        }

        if (DirectionSide > 0 && (transform.position.x >= _range))
        {
            //_tray.RotationTray(DirectionSide);
            DirectionSide = 0;
         //   _tray.SetPositionX(DirectionSide);
            SetPositionX(+_range);
        }

        Move(CalculateDirection(DirectionSide));


    }

    private Vector3 CalculateDirection(float directionSide)
    {
        return new Vector3(directionSide * _moveSpeedSide, 0, _moveSpeed);
    }

    private void Move(Vector3 direction)
    {
        transform.position = transform.position + (direction * Time.deltaTime);
    }

    private void SetPositionX(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
