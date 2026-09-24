using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class W3_Shotgun : MonoBehaviour
{
    [SerializeField] private float range = 8f;
    [SerializeField] private float coneAngle = 60f;
    [SerializeField] private float fireRate = 2f; 
    [SerializeField] private int pelletCount = 5;

    public GameObject bulletPrefab;
    public Transform player;

    private float nextFireTime;
    private LineRenderer lr;
    private float halfConeAngle;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 3;
        halfConeAngle = coneAngle * 0.5f;
    }

    void Start()
    {
        if (player == null)
        {
            W3_Player found = FindAnyObjectByType<W3_Player>();
            if (found != null) player = found.transform;
        }
    }

    void Update()
    {
        DrawCone();

        if (player != null && IsInCone(player.position))
        {
            if (Time.time >= nextFireTime)
            {
                FireShotgun();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public bool IsInCone(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;
        dir.y = 0f;

        if (dir.magnitude > range)
            return false;

        float pAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        float tAngle = transform.eulerAngles.y;

        float delta = Mathf.Abs(Mathf.DeltaAngle(tAngle, pAngle));

        return delta <= coneAngle / 2f;
    }
    public void DrawCone()
    {
        Vector3 origin = transform.position;
        Vector3 leftDir = Quaternion.Euler(0, -halfConeAngle, 0) * transform.forward;
        Vector3 rightDir = Quaternion.Euler(0, halfConeAngle, 0) * transform.forward;

        lr.SetPosition(0, origin);
        lr.SetPosition(1, origin + leftDir * range);
        lr.SetPosition(2, origin + rightDir * range);
    }

    public void FireShotgun()
    {
        Vector3 firePoint = transform.position + transform.forward * 1f;
        float angleSequence = coneAngle / pelletCount;
        float startAngle = -coneAngle / 2f;

        for (int i = 0; i < pelletCount; i++)
        {
            Quaternion rot = transform.rotation * Quaternion.Euler(0, startAngle, 0);
            Instantiate(bulletPrefab, firePoint, rot);
            startAngle += angleSequence;
        }
    }
}