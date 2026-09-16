using UnityEngine;

public class W2_ScreenBoundary : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    // Update is called once per frame
    void Awake()
    {
        //if cam is not assigned in the inspector, assign the main camera
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void screenBoundary(Transform player){

        //Convert the player's current 3D world position into a 0-to-1 screen position
        Vector3 viewportPos = cam.WorldToViewportPoint(player.transform.position);

        //Clamped the X (left/right) and Y (bottom/top) so that the view values strictly between 0.0 and 1.0
        //if the player go to the view value of 1.1, it will automatically make it 1, as well as 0.1 to 0
        viewportPos.x = Mathf.Clamp(viewportPos.x, 0.01f, 0.99f);
        viewportPos.y = Mathf.Clamp(viewportPos.y, 0.01f, 0.99f);

        //Convert that clamped screen coordinate back into the actual 3D world position
        player.transform.position = cam.ViewportToWorldPoint(viewportPos);
    }
}
