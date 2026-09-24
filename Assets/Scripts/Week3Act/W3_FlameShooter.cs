using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class W3_FlameShooter : MonoBehaviour
{
    public Transform player;

    [SerializeField]
    private float range = 5f;
    [SerializeField]
    private float coneAngle = 45f;

    private LineRenderer lr;
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        DrawCone();
        if (IsInCone())
        {
            Debug.Log("Player is in cone");

        }
    }
    public bool IsInCone()
    {
        Vector3 dir = player.position - transform.position;

        if (dir.magnitude > range) return false;

        float pAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;

        float tAngle = transform.eulerAngles.y;

        float delta = Mathf.Abs(Mathf.DeltaAngle(tAngle, pAngle));

        return delta <= coneAngle/2f;
    }
    public void DrawCone()
    {
        Vector3 origin = transform.position;
        Vector3 leftDir = Quaternion.Euler(0, -coneAngle / 2f, 0) * transform.forward;
        Vector3 rightDir = Quaternion.Euler(0, coneAngle / 2f, 0) * transform.forward;

        lr.SetPosition(0, origin);
        lr.SetPosition(1, origin + leftDir * range);
        lr.SetPosition(2, origin + rightDir * range);
    }


}
