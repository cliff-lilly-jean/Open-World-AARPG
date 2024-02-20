using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HumanoidLandController : MonoBehaviour
{
    Rigidbody _rigidbody = null;
    [SerializeField] HumanoidLandInput _input;

    Vector3 _playerMoveInput = Vector3.zero;

    [Header("Movement")]
    [SerializeField] float _movementMultiplier = 30.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _playerMoveInput = GetMoveInput();
        PlayerMove();

        _rigidbody.AddRelativeForce(_playerMoveInput, ForceMode.Force);
    }

    private Vector3 GetMoveInput()
    {
        return new Vector3(_input.moveInput.x, 0.0f, _input.moveInput.y);
    }

    private void PlayerMove()
    {
        _playerMoveInput = (new Vector3(_playerMoveInput.x * _movementMultiplier * _rigidbody.mass,
        _playerMoveInput.y,
        _playerMoveInput.z * _movementMultiplier * _rigidbody.mass));
    }
}
