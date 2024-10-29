using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] public float _mouseSensitivity = 50f;
    [SerializeField] public float _maxLookAngle = 180f;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _maxVelocityChange = 10f;
    [SerializeField] private float _distance = 5.75f;

    private float pitch = 0.0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var k = _mouseSensitivity * Time.deltaTime;
        var yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * k;

        pitch -= Input.GetAxis("Mouse Y") * k;
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        _playerCamera.transform.localEulerAngles = new Vector3(pitch, 0, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
   

    private void FixedUpdate()
    {
        var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        targetVelocity = transform.TransformDirection(targetVelocity) * _walkSpeed;

        var velocity = _rigidbody.velocity;
        var velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.y = 0;

        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}
