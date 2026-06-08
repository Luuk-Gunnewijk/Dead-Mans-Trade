using UnityEngine;
using System.Collections;

public class AIMovementNB : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("ShootPOS")]
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
        for (int i = 0; i < inShootPOS.Length; i++)
        {
            
        }
        /*Vector2 currentPlayerPOS = player.position;
        _inSightPOS = new Vector2(player.position.x + 4, player.position.y);
        transform.position = Vector2.MoveTowards(transform.position, _inSightPOS, moveSpeed * Time.deltaTime);*/
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
