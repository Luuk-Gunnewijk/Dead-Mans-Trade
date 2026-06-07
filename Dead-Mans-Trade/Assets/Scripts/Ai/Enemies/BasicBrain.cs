using UnityEngine;

public class BasicBrain : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Wander")]
    [SerializeField] private float wanderRadius;
    [SerializeField] private float pointReachedDistance;

    private Vector2 _targetPosition;

    private void Start()
    {
        PickNewRandomPoint();
    }

    private void Update()
    {
        MoveToTarget();

        if (Vector2.Distance(transform.position, _targetPosition) < pointReachedDistance)
        {
            PickNewRandomPoint();
        }
    }

    private void PickNewRandomPoint()
    {
        Vector2 randomDirection = Random.insideUnitCircle * wanderRadius;
        _targetPosition = (Vector2)transform.position + randomDirection;
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_targetPosition, 0.2f);
    }
}