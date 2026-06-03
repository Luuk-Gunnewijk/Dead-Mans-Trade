using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dash : MonoBehaviour
{
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
        dashTrail.emitting = true;
        _myRigidBody2D.AddForce(transform.up * DashSpeed, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        dashTrail.emitting = false;
        yield return new WaitForSeconds(DashCooldownTime);
        _canDash = true;
    }
}
