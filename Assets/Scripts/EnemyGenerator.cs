using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject prefabEnemy;
    public GameObject prefabPowerUp;

    void Start()
    {
        StartCoroutine(Generate());
        StartCoroutine(GeneratePowerUp());
    }

    IEnumerator Generate()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Vector3 pos = new Vector3(8f, Random.Range(-3f, 4f), 0);
            Instantiate(prefabEnemy, pos, Quaternion.identity);
        }
    }

    IEnumerator GeneratePowerUp()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            Vector3 pos = new Vector3(8f, Random.Range(-3f, 4f), 0);
            Instantiate(prefabPowerUp, pos, Quaternion.identity);
        }
    }
}