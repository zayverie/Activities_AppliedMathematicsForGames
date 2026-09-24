using UnityEngine;

public class Atan : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform[] enemy;
    [SerializeField] private float rotSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) return;
    
        foreach (Transform e in enemy)
        {
            if (e == null) return;
            // Calculate the direction from the current object to the enemy
            var dir = enemy[0].transform.position - player.transform.position;
            // Calculate the angle between the current object's forward direction and the direction to the enemy
            // The angle is measured in degrees
            var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, 
                Quaternion.Euler(0, angle, 0), 
                rotSpeed * Time.deltaTime);
                
            /*var dot = Vector3.Dot(transform.forward.normalized, dir.normalized);
            Debug.Log(dot);*/
        }
        
    }
}
