using UnityEngine;
using UnityEngine.AI;

public class BasicBrain : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2f, Vector2.zero, 10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.zero * 10f;

        Gizmos.DrawWireSphere(start, 2f);
        Gizmos.DrawWireSphere(end, 2f);
        Gizmos.DrawLine(start, end);
    }
}
