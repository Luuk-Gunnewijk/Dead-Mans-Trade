using UnityEngine;

public class BasicMovementNB : MonoBehaviour
{
    [Header("MoveSpeed")]
    [SerializeField] private float acceleration;
    [SerializeField] private float backwardsSpeed;
    [SerializeField] private float decelerationSpeed;

    [Header("RotationSpeed")]
    [SerializeField] private float rotationSpeed;

    private Rigidbody2D _rigidBody2D;
    private float _targetRotation;

    private void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _targetRotation = _rigidBody2D.rotation;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.up * 3, Color.red);
        RotateInputNB();
    }

    private void FixedUpdate()
    {
        RotatePlayerNB();
        PlayerMovementNB();
    }

    private void PlayerMovementNB()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigidBody2D.AddForce(transform.up * acceleration);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _rigidBody2D.AddForce(transform.up * -backwardsSpeed);
        }
        else
    {
        _rigidBody2D.linearVelocity = Vector2.Lerp(_rigidBody2D.linearVelocity, Vector2.zero, decelerationSpeed * Time.fixedDeltaTime);
    }
    }

    private void RotateInputNB()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _targetRotation += 90f;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _targetRotation -= 90f;
        }
    }

    private void RotatePlayerNB()
    {
        float newRotation = Mathf.MoveTowardsAngle(_rigidBody2D.rotation, _targetRotation, rotationSpeed * Time.fixedDeltaTime);
        _rigidBody2D.MoveRotation(newRotation);
    }
}