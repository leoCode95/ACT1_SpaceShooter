using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb2D;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2D.linearVelocity = Vector2.left * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}