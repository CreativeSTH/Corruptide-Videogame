using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs; // Array to hold different enemy prefabs
    [SerializeField] private float spawnInterval = 2f; // Time between spawns
    private float spawnX = 75f;

    void OnEnable()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(SpawnEnemy));
    }

    private void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0) return;

        float randomY = Random.Range(-35f, 35f);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);
        int randomIndex = Random.Range(0, enemyPrefabs.Length);

        GameObject newEnemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, enemyPrefabs[randomIndex].transform.rotation);
    }
}