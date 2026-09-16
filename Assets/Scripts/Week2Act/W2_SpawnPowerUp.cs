using UnityEngine;

public class W2_PowerUpSystem : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject powerUpPrefab;
    public float spawnInterval = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= spawnInterval)
        {
            SpawnPowerUp();
            spawnInterval = Time.time + 5f;
        }
    }

    public void SpawnPowerUp()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform randomSpawnPoint = spawnPoints[randomIndex];
        Instantiate(powerUpPrefab, randomSpawnPoint.position, Quaternion.identity);
    }
}
