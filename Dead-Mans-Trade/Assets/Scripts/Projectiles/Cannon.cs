using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Speed")]
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigidBody2D.linearVelocity = transform.right * moveSpeed;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemies"))
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
