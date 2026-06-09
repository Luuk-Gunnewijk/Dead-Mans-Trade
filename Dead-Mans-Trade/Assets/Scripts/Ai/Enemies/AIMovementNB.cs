using UnityEngine;
using System.Collections;

public class AIMovementNB : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("EnemyPOS")]
    [SerializeField] private Transform[] inEnemyPOS;

    private float _minROTTime = 0.2f;
    private float _maxROTTime = 2f;

    private Transform player;
    private Vector2 _inSightPOS;

    void Start()
    {
        player = PlayerNB.Instance.transform; 
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

        for (int i = 0; i < inEnemyPOS.Length; i++)
        {
            float dist = Vector2.Distance(inEnemyPOS[i].position, transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestShootPos = inEnemyPOS[i];
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
        float randomTime = Random.Range(_minROTTime, _maxROTTime);
        yield return new WaitForSeconds(randomTime);
        transform.rotation = player.rotation;
    }
}
