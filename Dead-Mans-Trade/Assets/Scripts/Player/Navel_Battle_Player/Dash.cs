using System.Collections;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public bool IsDashing { get; private set; }

    [Header("Dash Speed")]
    [SerializeField] private float DashSpeed;
    [SerializeField] private float decelerationSpeed;

    [Header("Times")]
    [SerializeField] private int DashCooldownTime;

    [Header("TrailRenderer")]
    [SerializeField] private TrailRenderer dashTrail;

    private bool _canDash = true;
    private Rigidbody2D _myRigidBody2D;

    private void Start()
    {
        _myRigidBody2D = GetComponent<Rigidbody2D>();
        dashTrail.emitting = false;
    }

    private void Update()
    {
        Dashing();
    }

    private void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            StartCoroutine(DashRoutine());
        }
    }

    private IEnumerator DashRoutine()
    {
        _canDash = false;
        IsDashing = true;
        dashTrail.emitting = true;
        _myRigidBody2D.linearVelocity = Vector2.zero;
        _myRigidBody2D.AddForce(transform.up * DashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        dashTrail.emitting = false;
        _myRigidBody2D.linearVelocity = Vector2.zero;
        IsDashing = false;
        yield return new WaitForSeconds(DashCooldownTime);
        _canDash = true;
    }
}
