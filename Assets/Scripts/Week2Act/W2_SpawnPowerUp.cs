using UnityEngine;

public class W2_PowerUpSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject powerUpPrefab;
    public float spawnInterval = 5f;

    private GameObject[] activePowerUps;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnPoints != null)
        {
            activePowerUps = new GameObject[spawnPoints.Length];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnInterval)
        {
            SpawnPowerUp();
            spawnInterval = Time.time + 5f; // Reset the spawn interval to 5 seconds from the current time
        }
    }

    public void SpawnPowerUp()
    {
        if (spawnPoints == null || spawnPoints.Length == 0) return;

        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Prevents spawning if a power-up is already alive at this spot
        if (activePowerUps[randomIndex] != null) return;

        Transform randomSpawnPoint = spawnPoints[randomIndex];
        activePowerUps[randomIndex] = Instantiate(powerUpPrefab, randomSpawnPoint.position, Quaternion.identity);
    }
}