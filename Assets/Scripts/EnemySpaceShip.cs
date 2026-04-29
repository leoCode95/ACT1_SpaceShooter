using System.Collections;
using UnityEngine;

public class EnemySpaceShip : MonoBehaviour
{
    public float speed = 2f;
    public GameObject prefabShot;
    public float fireRate = 2f;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRate);
            if (prefabShot != null)
                Instantiate(prefabShot, transform.position, Quaternion.identity);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}