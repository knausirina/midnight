using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _playerCamera;

    [SerializeField] public float _mouseSensitivity = 50f;
    [SerializeField] private float _walkSpeed = 5f;

    private float _pitch = 0.0f;
    private float _yaw = 0.0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var k = _mouseSensitivity * Time.deltaTime;
 
        _pitch -= Input.GetAxis("Mouse Y") * k;
        _yaw += Input.GetAxis("Mouse X") * k;
        
        _playerCamera.transform.localEulerAngles = new Vector3(_pitch, _yaw, 0.0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
   

    private void FixedUpdate()
    {
        var forwardMovement = _playerCamera.transform.forward * Input.GetAxis("Vertical");
        var horizontalMovement = _playerCamera.transform.right * Input.GetAxis("Horizontal");
        var movement = Vector3.ClampMagnitude(forwardMovement + horizontalMovement, 1);
        transform.Translate(movement * _walkSpeed * Time.deltaTime, Space.World);
    }
}
