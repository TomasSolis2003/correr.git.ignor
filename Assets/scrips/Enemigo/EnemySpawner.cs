using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a spawnear
    public float spawnInterval = 3f; // Intervalo de tiempo entre spawns

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null) // Aseg�rate de que el prefab no sea null
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("enemyPrefab no est� asignado en el inspector.");
        }
    }
}

