using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class W5_UIManager : MonoBehaviour
{
    public GameObject healthUI;
    public GameObject timeUI;
    [HideInInspector] public W5_Player playerScript;
    [HideInInspector] public W5_GameManager gameManagerScript;
    
    void Start()
    {
        if (playerScript == null)
        {
            playerScript = FindAnyObjectByType<W5_Player>();
        }

        if (gameManagerScript == null)
        {
            gameManagerScript = FindAnyObjectByType<W5_GameManager>();
        }
    }
    void Update()
    {
        if (timeUI != null)
        {
            TextMeshProUGUI timeText = timeUI.GetComponent<TextMeshProUGUI>();
            if (timeText != null)
            {
                timeText.text = "Time: " + (Time.time - gameManagerScript.zeroTime).ToString("F2") + "s";
            }
        }
    }
    public void UpdateHealthUI()
    {
        if (playerScript != null && healthUI != null)
        {
            TextMeshProUGUI healthText = healthUI.GetComponent<TextMeshProUGUI>();
            if (healthText != null)
            {
                healthText.text = "Health: " + playerScript.health.ToString("F0");
            }
        }
    }
    
    
}
