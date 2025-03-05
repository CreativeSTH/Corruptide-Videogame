using UnityEngine;

public class MissileBoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject missileBoxPrefab; // Prefab de la caja de misiles
    [SerializeField] private float gameTime = 120f; // Tiempo total del juego en segundos
    private float spawnX = 75f;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = gameTime - 10f; // Primera caja aparece cuando queden 105s
    }

    void Update()
    {
        gameTime -= Time.deltaTime; // Reducimos el tiempo

        if (gameTime <= nextSpawnTime)
        {
            SpawnMissileBox();
            nextSpawnTime -= 10f; // Configuramos el próximo spawn cada 15 segundos
        }
    }

    private void SpawnMissileBox()
    {
        if (missileBoxPrefab == null) return;

        float randomY = Random.Range(-35f, 35f);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        Instantiate(missileBoxPrefab, spawnPosition, Quaternion.identity);
    }
}
