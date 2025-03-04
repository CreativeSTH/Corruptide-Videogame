using System.Collections;
using UnityEngine;

public class EnemySpawnerLVL2 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 3f;
    private Vector3 spawnPosition;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    private void Update()
    {
        float randomY = Random.Range(0f, 5f);
        spawnPosition = new Vector3(CameraController.xPosition + 20f, randomY, -2);
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyPrefab = enemyPrefabs[randomIndex];
        

        if (enemyPrefab.CompareTag("A10"))
        {            
            float a10Delay = 1; // Reset delay before spawning A10 enemies
            for (int i = 0; i < 3; i++)
            {
                StartCoroutine(SpawnA10(enemyPrefab, i, a10Delay));
                a10Delay += 1;
            }
        }
        else
        {
            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        }
    }

    private IEnumerator SpawnA10(GameObject pref, int i, float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(pref, spawnPosition, pref.transform.rotation);;
    }
}
