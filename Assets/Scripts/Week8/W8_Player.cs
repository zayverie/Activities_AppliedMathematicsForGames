using UnityEngine;
using UnityEngine.SceneManagement;

public class W8_Player : MonoBehaviour
{
    public static W8_Player Instance => instance;
    private static W8_Player instance;
    private float velocity = 5f;
    private float jumpForce = 5f;
    private float gravity = 9.81f;
    public float verticalVelocity {get; private set;}
    public bool isGrounded;
    public bool isCollidingWithObstacle;
    public bool _jumpPressed;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpPressed = true;
        }
    }

    void FixedUpdate()
    {  
        Vector3 playerDirection = new Vector3(
            Input.GetAxisRaw("Horizontal"),
            0f,
            0f);

        transform.position += playerDirection.normalized * velocity * Time.fixedDeltaTime;
        

        AABBCollider collider = GetComponent<AABBCollider>();
        collider.FixedUpdate();
        
        if (_jumpPressed && isGrounded)
        {
            Debug.Log("Jump pressed");
            verticalVelocity = jumpForce;
            isGrounded = false;
            isCollidingWithObstacle = false;
        }
        isGrounded = false;
        isCollidingWithObstacle = false;
        _jumpPressed = false;
        verticalVelocity -= gravity * Time.fixedDeltaTime;
        transform.position += new Vector3(0f, verticalVelocity * Time.fixedDeltaTime, 0f);

        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public float ResetVerticalVelocity()
    {
        verticalVelocity = 0f;
        return verticalVelocity;
    }
}
    
