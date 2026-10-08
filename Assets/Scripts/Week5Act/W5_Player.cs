using UnityEngine;

public class W5_Player : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float strafeSpeed = 12f;
    public float health = 5f;
    public W5_UIManager uiManagerScript;
    private HomingMissiles homingMissilesScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (uiManagerScript != null)
        {
            uiManagerScript.UpdateHealthUI();
        }

        if (homingMissilesScript == null)
        {
            homingMissilesScript = FindAnyObjectByType<HomingMissiles>();
        }

        if (uiManagerScript == null)
        {
            uiManagerScript = FindAnyObjectByType<W5_UIManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * strafeSpeed, 0f, forwardSpeed) * Time.deltaTime;

        transform.Translate(movement, Space.World); 
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, -horizontalInput * 30f);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (uiManagerScript != null)
        {
            uiManagerScript.UpdateHealthUI();
        }
        Debug.Log("Player hit! Health: " + health);
    }
}
