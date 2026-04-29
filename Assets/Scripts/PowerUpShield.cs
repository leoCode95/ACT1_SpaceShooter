using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}