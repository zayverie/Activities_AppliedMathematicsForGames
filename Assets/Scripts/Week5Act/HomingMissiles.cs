using UnityEngine;

public class HomingMissiles : MonoBehaviour
{
    private float lifetime = 5f;
    public float speed = 10f;
    public W5_Player playerScript;
    private float turnSpeed = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerScript == null)
        {
            playerScript = FindAnyObjectByType<W5_Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0f)
        {
            SetTarget();
            transform.position += transform.forward * speed * Time.deltaTime;
            lifetime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        HitTarget();
    }

    public void SetTarget()
    {
        Vector3 direction = (playerScript.transform.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
    }

    public bool HitTarget()
    {
        if ((transform.position - playerScript.transform.position).magnitude < 1.2f)
        {
            playerScript.TakeDamage(1f);
            Destroy(gameObject);
            Debug.Log("Hit the target!");
            return true;
        }
        else
        {
            return false;
        }
    }
}
