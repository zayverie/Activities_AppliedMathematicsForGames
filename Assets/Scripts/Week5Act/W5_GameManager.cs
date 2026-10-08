using UnityEngine;
using UnityEngine.SceneManagement;

public class W5_GameManager : MonoBehaviour
{
    private W5_Player playerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
