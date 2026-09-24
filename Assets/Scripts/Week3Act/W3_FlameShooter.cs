using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class W3_FlameShooter : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private float coneAngle = 45f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private int flameCount = 5;

    public GameObject flamePrefab;
    public W3_Player playerScript;

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
        playerScript = FindAnyObjectByType<W3_Player>();
    }

    void Update()
    {
        DrawCone();

        if (playerScript != null && IsInCone(playerScript.transform.position))
        {
            if (Time.time >= nextFireTime)
            {
                FireFlame();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    public bool IsInCone(Vector3 targetPosition)
    {
        Vector3 dir = targetPosition - transform.position;
        dir.y = 0f; // Restrict checks to XZ ground plane

        if (dir.sqrMagnitude > range) return false;

        return Vector3.Angle(transform.forward, dir) <= halfConeAngle;
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

    public void FireFlame()
    {
        Vector3 firePoint = transform.position + transform.forward * 1f;

        float angleSequence = coneAngle / flameCount;
        float angle = -coneAngle / 2f; // Start at the left edge of the cone

        for (int i = 0; i < flameCount; i++)
        {
            Quaternion rot = transform.rotation * Quaternion.Euler(0, angle, 0);

            GameObject flame = Instantiate(flamePrefab, firePoint, rot);
            flame.GetComponent<W3_Flame>().flameShooterScript = this;

            angle += angleSequence;
        }
    }
}