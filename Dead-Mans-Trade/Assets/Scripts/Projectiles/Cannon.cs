using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rigidBody2D.linearVelocity = transform.right * moveSpeed;
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag != "Enemies") return;
        Destroy(gameObject, 0.2f);
    }
}
