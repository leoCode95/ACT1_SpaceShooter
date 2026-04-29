using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D rb2D;

    public GameObject explosionPrefab;

    public AudioClip explosionSound;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rb2D.linearVelocity = Vector2.right * speed;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore(10);

            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, other.transform.position);
            }

            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}