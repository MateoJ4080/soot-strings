using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _cam;
    [SerializeField] private Transform _camPivot;
    [SerializeField] private float _mouseSensitivity = 100f;

    [Header("Head Bobbing")]
    private float _bobTimer;
    private float _previousPhase;
    private Vector2 _bobWeight;
    private Vector3 _initialPosition;
    [SerializeField] private float _bobReturnSpeed;
    [SerializeField] private Vector2 _bobAmplitude;
    [SerializeField] private Vector2 _bobFrequency;

    private float _xRotation = 0f;
    private Vector2 _lookInput;

    void Start()
    {
        _initialPosition = _camPivot.localPosition;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
    }

    void LateUpdate()
    {
        ApplyHeadBob();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _lookInput = context.ReadValue<Vector2>();
    }

    private void RotateCamera()
    {
        float mouseX = _lookInput.x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _lookInput.y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _cam.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void ApplyHeadBob()
    {
        var playerVelocity = _player.GetComponent<CharacterController>().velocity;

        bool isMoving = playerVelocity.magnitude > 0.1f;
        if (isMoving) _bobTimer += Time.deltaTime;

        _bobWeight.x = Mathf.Lerp(_bobWeight.x, isMoving ? 1f : 0f, Time.deltaTime * _bobReturnSpeed);
        _bobWeight.y = Mathf.Lerp(_bobWeight.y, isMoving ? 1f : 0f, Time.deltaTime * _bobReturnSpeed);

        var bobX = Mathf.Cos(_bobTimer * _bobFrequency.x * Mathf.PI * 2f) * _bobAmplitude.x * 0.01f;
        var bobY = Mathf.Sin(_bobTimer * _bobFrequency.y * Mathf.PI * 2f) * _bobAmplitude.y * 0.01f;

        _camPivot.localPosition = _initialPosition + new Vector3(bobX * _bobWeight.x, bobY * _bobWeight.x, 0f);

        // Normalize a full sine cycle to a [0-1] value.
        float phase = _bobTimer * _bobFrequency.y % 1f;

        // 0.75 because, after normalized, it represents sine -1 (3π/2).
        if (isMoving && _previousPhase < 0.75f && phase >= 0.75f) _player.GetComponent<PlayerController>().PlayFootstepSound();

        _previousPhase = phase;
    }
}
