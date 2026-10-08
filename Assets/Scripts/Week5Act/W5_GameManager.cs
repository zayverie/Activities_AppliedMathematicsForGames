using UnityEngine;
using UnityEngine.SceneManagement;

public class W5_GameManager : MonoBehaviour
{
    private W5_Player playerScript;
    [HideInInspector] public float zeroTime = 0f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zeroTime = Time.time;
        if (playerScript == null)
        {
            playerScript = FindAnyObjectByType<W5_Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript != null && playerScript.health <= 0f)
        {
            RestartGame();
        }
    }

    public bool RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        return true;    
    }
}
