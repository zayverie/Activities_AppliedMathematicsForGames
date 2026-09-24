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

    void Update()
    {
        WinCondition();
    }

    public void WinCondition()
    {
        if (playerScript != null && uiManagerScript != null && goal != null)
        {
            if (Vector3.Distance(playerScript.transform.position, goal.transform.position) < 1f)
            {
                uiManagerScript.WinGame();

                if (sniperScript != null) sniperScript.enabled = false;
                if (flameShooterScript != null) flameShooterScript.enabled = false;
                if (shotgunScript != null) shotgunScript.enabled = false;
                if (turretRotationScript != null) turretRotationScript.enabled = false;
                
                playerScript.enabled = false;
                enabled = false;
            }
        }
    }
}