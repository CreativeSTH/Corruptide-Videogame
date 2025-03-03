using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject [] prefabEnemy;
    float rangSpawn = 9.5f;
    float positionY = 10.5f;
    float positionZ = -0.35f;
    float timeStart = 2.0f;
    float intervalSpawn = 1.5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("generateEnemyRandom", timeStart, intervalSpawn);
    }

    void generateEnemyRandom(){
        int indexEnemy = Random.Range(0, prefabEnemy.Length);

        Vector3 positionGenerate = new Vector3(Random.Range(-rangSpawn, rangSpawn) , positionY, positionZ);
        Instantiate(prefabEnemy[indexEnemy], positionGenerate, prefabEnemy[indexEnemy].transform.rotation);
    }
}
