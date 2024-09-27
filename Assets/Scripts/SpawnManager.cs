using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Obtiene el prefab del enemigo
    public GameObject enemyPrefab;

    // Número de enemigos a instanciar
    public int numberOfEnemies;

    // Obtiene el transform del punto de spawn específico
    public Transform spawnPoint;

    private void Start()
    {
        SpawnEnemies();
    }

    // Método para instanciar los enemigos
    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Instancia al enemigo en el punto de spawn específico
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}