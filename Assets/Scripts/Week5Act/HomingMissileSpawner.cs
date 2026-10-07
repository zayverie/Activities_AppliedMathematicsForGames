using UnityEngine;

public class HomingMissileSpawner : MonoBehaviour
{
    public float spawnPointOffset = -10f;
    public float spawnInterval = 3f;
    public GameObject missilePrefab;
    private float nextSpawnTime = 0f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        {
            W5_Player playerScript = GameObject.FindAnyObjectByType<W5_Player>();
           
            if(playerScript != null)
            {
                target = playerScript.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            LaunchMissile();
            nextSpawnTime = Time.time + spawnInterval; 
        }

        if (Time.time > 10f)
        {
            spawnInterval += 1f; 
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
        Instantiate(missilePrefab, spawnPoint, Quaternion.identity); 

    }
}
