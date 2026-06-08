using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float minMoveSpeed;
    [SerializeField] private float maxMoveSpeed;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    private float currentSpeed;

    void Start()
    {
        Destroy(gameObject, 3f);

        currentSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rigidBody2D.linearVelocity = transform.right * currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag != "Enemies") return;
        Destroy(gameObject, 0.2f);
    }
}
