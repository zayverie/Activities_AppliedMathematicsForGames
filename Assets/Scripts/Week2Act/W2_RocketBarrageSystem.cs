using UnityEngine;

public class W2_RocketBarrageSystem : MonoBehaviour
{
    public int rocketCount = 0;
    public float fireInterval = 5f;
    public GameObject rocketPrefab;
    public float maxRocketCount = 8f;

    public W2_PlayerMovement playerMovementScript;

    // Update is called once per frame
    void Update()
    {
        Vector3 firePoint = playerMovementScript.player.transform.position;

        if (Time.time >= fireInterval)
        {
            SpawnRocket(firePoint);
            fireInterval = Time.time + 5f; // Reset the fire interval to 5 seconds from the current time
        }
    }

    public void SpawnRocket(Vector3 firePoint)
    {
        float angleSequence = 360f / rocketCount;
        float angle = angleSequence / 4f;

        for (int i = 0; i < rocketCount; i++)
        {
            Instantiate(rocketPrefab, firePoint, Quaternion.Euler(0, angle, 0));

            angle += angleSequence;
        } 
    }
}