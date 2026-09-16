using UnityEngine;

public class W2_RocketBarrageSystem : MonoBehaviour
{
    public int numberOfRockets = 5;
    public float fireInterval = 3f;
    public GameObject rocketPrefab;
    public float maxNumberOfRockets = 8f;

    public W2_PlayerMovement playerMovementScript;

    // Update is called once per frame
    void Update()
    {
        Vector3 firePoint = playerMovementScript.player.transform.position;

        if (Time.time >= fireInterval && numberOfRockets <= maxNumberOfRockets)
        {
            SpawnRocket(firePoint);
            fireInterval = Time.time + 3f;
        }

        if(numberOfRockets == maxNumberOfRockets)
        {
            Debug.Log("Maximum number of rockets reached. Cannot spawn more rockets.");
        }
    }

    public void SpawnRocket(Vector3 firePoint)
    {
        float angleSequence = 360 / numberOfRockets;
        float angle = 0;

        for (int i = 0; i < numberOfRockets; i++)
        {
            float xDirPos = Mathf.Cos(angle * Mathf.Rad2Deg);
            float zDirPos = Mathf.Sin(angle * Mathf.Rad2Deg);

            // Calculate the spawn position based on the fire point and the calculated x and z offsets
            Vector3 spawnPosition = new Vector3(firePoint.x + xDirPos, firePoint.y, firePoint.z + zDirPos); 
            Instantiate(rocketPrefab, spawnPosition, Quaternion.Euler(0, angle, 0));

            angle += angleSequence;
        } 
    }
}
