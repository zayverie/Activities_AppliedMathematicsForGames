using UnityEngine;

public class W2_Rocket : MonoBehaviour
{
    public float rocketSpeed = 5f;
    public float rocketLifetime = 3f;
    public float timeSinceSpawned = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * rocketSpeed * Time.deltaTime);
        timeSinceSpawned += Time.deltaTime;

        if (timeSinceSpawned >= rocketLifetime)
        {
            Destroy(this.gameObject);
        }
    }
}