using UnityEngine;

public class HomingMissileSpawner : MonoBehaviour
{
    public float spawnPointOffset = -10f;
    private float spawnInterval = 10f;
    public GameObject missilePrefab;
    private float nextSpawnTime = 0f;
    public Transform target;
    // private float difficultyElapsedTime = 0f; 
    private int missileToSpawn = 1;
    public W5_GameManager gameManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (target == null)
        {
            W5_Player playerScript = FindAnyObjectByType<W5_Player>();
           
            if(playerScript != null)
            {
                target = playerScript.transform;
            }
        }

        if (gameManagerScript == null)
        {
            gameManagerScript = FindAnyObjectByType<W5_GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            for (int i = 0; i < missileToSpawn; i++)
            {
                LaunchMissile();
            }
            missileToSpawn++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
    public void LaunchMissile()
    {
        if (missilePrefab == null)
        {
            return;
        }
        Vector3 referencePosition = target.position; 
        Vector3 spawnPoint = referencePosition + (Vector3.back * spawnPointOffset); 

        spawnPoint.x += Random.Range(-5f, 5f);

        Instantiate(missilePrefab, spawnPoint, Quaternion.identity); 

    }
}
