using UnityEngine;

public class W2_Rocket : MonoBehaviour
{
    public float rocketSpeed = 5f;
    public float timeToDestroy = 5f;
    public float timeSinceSpawned = 0f;
    public float maxDistance = 10f; // Maximum distance from the fire point to spawn rockets


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
        timeSinceSpawned += Time.deltaTime;

        if(timeSinceSpawned >= timeToDestroy)
        {
            Destroy(this.gameObject);
            Debug.Log("Player is too far from the fire point. Rockets will not spawn.");
        }
    }
}
