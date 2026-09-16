using UnityEngine;

public class W2_PlayerMovement : MonoBehaviour
{
    public Transform player;
    public float velocity = 0;
    public float acceleration = 5f;
    public float maxVelocity = 10f;

    [SerializeField]
    private W2_ScreenBoundary screenBoundaryScript;

    private Vector3 lastDirection = Vector3.zero;

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
        
        // sqrMagnitude avoids unnecessary square roots
        if (movement.sqrMagnitude > 0f)
        {
            lastDirection = movement;
            if (velocity < maxVelocity)
            {
                velocity += acceleration * Time.deltaTime; //accelerate when input is given
            }
        }
        else
        {
            velocity -= acceleration * Time.deltaTime; //decelerate when no input is given
        }

        velocity = Mathf.Clamp(velocity, 0f, maxVelocity);

        if (velocity > 0f)
        {
            player.transform.position += lastDirection * velocity * Time.deltaTime;
            screenBoundaryScript.screenBoundary(player.transform);
        }
    }
}