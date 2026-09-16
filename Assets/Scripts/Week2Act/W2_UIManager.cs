using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class W2_UIManager : MonoBehaviour
{
    [SerializeField] private W2_PlayerMovement playerMovementScript;
    [SerializeField] private W2_RocketBarrageSystem rocketBarrageSystemScript;

    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI rocketCountText;
    public TextMeshProUGUI fireTimerText;
    public TextMeshProUGUI rocketLifetimeText;

    void Update()
    {
        if (velocityText != null && playerMovementScript != null)
        {
            velocityText.text = $"Speed: {playerMovementScript.velocity:F1} / {playerMovementScript.maxVelocity:F1}";
        }

        if (rocketCountText != null && rocketBarrageSystemScript != null)
        {
            string capStatus = rocketBarrageSystemScript.rocketCount >= rocketBarrageSystemScript.maxRocketCount ? " (MAX)" : "";
            rocketCountText.text = $"Rockets: {rocketBarrageSystemScript.rocketCount}/{rocketBarrageSystemScript.maxRocketCount}{capStatus}";
        }

        if (fireTimerText != null && rocketBarrageSystemScript != null)
        {
            float timeRemaining = Mathf.Max(0f, rocketBarrageSystemScript.fireInterval - Time.time);
            fireTimerText.text = $"Next Barrage: {timeRemaining:F1}s";
        }

        if (rocketLifetimeText != null)
        {
            W2_Rocket activeRocket = FindAnyObjectByType<W2_Rocket>();

            if (activeRocket != null)
            {
                float rocketTimeLeft = Mathf.Max(0f, activeRocket.rocketLifetime - activeRocket.timeSinceSpawned);
                rocketLifetimeText.text = $"Rocket Lifetime: {rocketTimeLeft:F1}s";
            }
            else
            {
                rocketLifetimeText.text = "Rocket Lifetime: --";
            }
        }
    }
}