using UnityEngine;

public class LerpMoves : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform controlA, controlB;
    [SerializeField] private float timeToReachTarget;
    [SerializeField]

    private float totalTime;
    private Vector3 initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null ) return;

        totalTime += Time.deltaTime;

        var lerpedTime = Mathf.Clamp01(totalTime / timeToReachTarget);

        //explain in detail: 
        // The line of code `transform.position = QuadraticFast(initialPosition, controlPoint.position, target.position, lerpedTime);` is responsible for moving the GameObject from its initial position to the target position over time, using a quadratic Bezier curve interpolation method.
        // Here's a breakdown of the components:
        // - `initialPosition`: The starting position of the GameObject.
        // - `controlPoint.position`: The control point that defines the curvature of the path.
        // - `target.position`: The desired end position of the GameObject.
        // - `lerpedTime`: The interpolation factor, which is clamped between 0 and 1 to ensure it doesn't exceed the bounds of the interpolation.
        // - `Mathf.Pow(lerpedTime, 0.5f)`: The non-linear interpolation factor, which eases the movement over time.
        // a + (b - a) * t is the formula for linear interpolation, where:
        // - `a` is the starting value (initialPosition)
        // - `b` is the ending value (target.position)
        // - `t` is the interpolation factor (lerpedTime), which is clamped between 0 and 1 to ensure it doesn't exceed the bounds of the interpolation.
        
        // transform.position = QuadraticFast(initialPosition, controlPoint.position, target.position, Mathf.Pow(lerpedTime, 0.5f));

        transform.position = CubicFast(initialPosition, controlA.position, controlB.position, target.position, lerpedTime);

        Debug.Log($"Lerped Time: {lerpedTime}, Total Time: {totalTime}");
    }
    [ContextMenu("Reset Position")]
    public void ResetPosition()
    {
        totalTime = 0f;
        transform.position = initialPosition;
    }
    public static Vector3 QuadraticFast(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        float u  = 1f - t;
        return u * u * p0  +  2f * u * t * p1  +  t * t * p2;
    }
    public static Vector3 CubicFast(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float u = 1f - t;
        return u*u*u*p0  +  3*u*u*t*p1  +  3*u*t*t*p2  +  t*t*t*p3;
    }

    private void OnDrawGizmos()
    {
        var previousLine = initialPosition;
        for(int i = 0; i <= 10; i++)
        {
            var t = i / 10f;
            var newPos = CubicFast(initialPosition, controlA.position, controlB.position, target.position, t);
            Debug.DrawLine(previousLine, newPos, Color.red);
            previousLine = newPos;
        }
    }

}
