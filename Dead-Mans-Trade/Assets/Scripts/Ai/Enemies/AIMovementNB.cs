using UnityEngine;
using System.Collections;

public class AIMovementNB : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("ShootPOS && Player")]
    [SerializeField] private Transform[] inShootPOS;
    [SerializeField] private Transform player;

    private Vector2 _inSightPOS;

    void Start()
    {

    }

    void Update()
    {
        Movement();
        CheckPlayerRotation();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_inSightPOS, 0.2f);
    }

    private void Movement()
    {
        Transform closestShootPos = null;
        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < inShootPOS.Length; i++)
        {
            float dist = Vector2.Distance(inShootPOS[i].position, transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestShootPos = inShootPOS[i];
            }
        }
        if (closestShootPos == null) return;
        _inSightPOS = closestShootPos.position;
        transform.position = Vector2.MoveTowards( transform.position, _inSightPOS, moveSpeed * Time.deltaTime);
    }

    private void CheckPlayerRotation()
    {
        if(player.rotation != transform.rotation)
        {
            StartCoroutine(RotateAIRoutine());
        }
    }

    private IEnumerator RotateAIRoutine()
    {
        yield return new WaitForSeconds(.2f);
        transform.rotation = player.rotation;
    }
}
