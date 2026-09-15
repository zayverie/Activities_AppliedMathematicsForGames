using UnityEngine;

public class W2_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public float velocity = 0;
    public float acceleration = 5f;
    public float maxVelocity = 10f;

    [Header("Camera Limits")]
    private Vector2 screenBounds;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // -1, 0, 1 --> so to prevent diagonal movement, set horizontal and vertical input to 0 if both are pressed
        if (horizontalInput != 0 && verticalInput != 0)
        {
            horizontalInput = 0;
            verticalInput = 0;
        }

        Vector3 movement = new Vector3(
            horizontalInput, 
            0, 
            verticalInput).normalized;
        
        if (movement.magnitude > 0 && velocity < maxVelocity)
        {
            velocity += acceleration * Time.deltaTime; //accelerate when input is given
        }
        else
        {
            velocity -= acceleration * Time.deltaTime; //decelerate when no input is given
        }

        // Clamp the velocity to ensure it doesn't go below 0 or above maxVelocity
        if (velocity < 0)
        {
            velocity = 0;
        }
        else if (velocity > maxVelocity)
        {
            velocity = maxVelocity;
        }
        
        player.transform.position += movement * velocity * Time.deltaTime;

        Debug.Log($"Player Position: {player.transform.position}, Velocity: {velocity}");
    }
}
