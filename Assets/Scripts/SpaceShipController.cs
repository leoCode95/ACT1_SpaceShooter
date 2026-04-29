using UnityEngine;
using TMPro;

public class SpaceShipController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb2D;
    public GameObject prefabShot;
    public float fireRate = 0.3f;
    float nextFire = 0f;
    public int lives = 3;
    public TextMeshProUGUI livesText;
    public AudioClip shootSound;
    public bool hasShield = false;
    public float shieldDuration = 5f;
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI shieldText;
    public GameOverMenu gameOverMenu;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Time.time > 0.1f)
        {
            rb2D.linearVelocity = new Vector2(moveX * speed, moveY * speed);
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -7f, 7f);
        pos.y = Mathf.Clamp(pos.y, -4f, 4f);
        transform.position = pos;

        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(prefabShot, transform.position + Vector3.right * 1.2f, Quaternion.identity);
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!hasShield)
            {
                lives--;
                UpdateLivesUI();
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("EnemyShot"))
        {
            if (!hasShield)
            {
                lives--;
                UpdateLivesUI();
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PowerUp"))
        {
            ActivateShield();
            Destroy(other.gameObject);
        }
    }

    void ActivateShield()
    {
        hasShield = true;
        spriteRenderer.color = Color.cyan;
        shieldText.gameObject.SetActive(true);
        Invoke("RemoveShield", shieldDuration);
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + lives;
        
        if (lives <= 0)
        {
            hasShield = false;
            gameOverMenu.ShowGameOver();
        }
    }

    void RemoveShield()
    {
        hasShield = false;
        spriteRenderer.color = Color.white;
        shieldText.gameObject.SetActive(false);
    }


}