using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fishPrefabs; // Array de prefabs de peixes
    public GameObject[] trashPrefabs; // Array de prefabs de resíduos
    public float initialSpawnInterval = 2f; // Intervalo inicial entre spawns
    private float currentSpawnInterval;
    public float spawnIntervalDecreaseRate = 0.1f; // Taxa de redução do intervalo de spawn
    public float initialSpeed = 2.0f; // Velocidade inicial dos elementos
    public float speedIncreaseRate = 1.0f; // Fator de aumento da velocidade
    private float timeElapsed;

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        Invoke("SpawnRandomObject", currentSpawnInterval);
    }

    void Update()
    {
        // Aumenta o tempo decorrido
        timeElapsed += Time.deltaTime;

        // Reduz o intervalo de spawn ao longo do tempo, até um limite mínimo
        currentSpawnInterval = Mathf.Max(0.5f, initialSpawnInterval - (spawnIntervalDecreaseRate * timeElapsed));
    }

    void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, transform.childCount); // Escolhe um dos pontos de geração
        Transform spawnPoint = transform.GetChild(randomIndex);

        // Decide se deve gerar um peixe ou resíduo
        bool spawnFish = Random.value > 0.5f;
        GameObject[] prefabs = spawnFish ? fishPrefabs : trashPrefabs;

        int prefabIndex = Random.Range(0, prefabs.Length);
        GameObject spawnedObject = Instantiate(prefabs[prefabIndex], spawnPoint.position, Quaternion.identity);

        // Define a velocidade do objeto gerado
        float currentSpeed = initialSpeed + (speedIncreaseRate * (timeElapsed / 20)); // Ajuste de acordo com o tempo
        HorizontalMovement moveLeft = spawnedObject.GetComponent<HorizontalMovement>();
        if (moveLeft != null)
        {
            moveLeft.SetSpeed(currentSpeed);
        }

        // Invoca o próximo spawn baseado no intervalo atual
        Invoke("SpawnRandomObject", currentSpawnInterval);
    }
}
