using UnityEngine;

public class W3_GameManager : MonoBehaviour
{
    public W3_Player playerScript;
    public W3_UIManager uiManagerScript;
    public W3_Sniper sniperScript;
    public W3_FlameShooter flameShooterScript;
    public W3_Shotgun shotgunScript;
    public W3_TurretRotation turretRotationScript;
    public GameObject goal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WinCondition();
    }

    public void WinCondition()
    {
        if (playerScript != null && uiManagerScript != null && goal != null)
        {
            if ((playerScript.transform.position - goal.transform.position).magnitude < 1f)
            {
                uiManagerScript.WinGame();
                sniperScript.enabled = false;
                flameShooterScript.enabled = false;
                shotgunScript.enabled = false;
                turretRotationScript.enabled = false;
                playerScript.enabled = false;
            }
        }
    }
}
