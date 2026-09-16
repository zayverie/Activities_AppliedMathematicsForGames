using UnityEngine;


public class W2_PowerUps : MonoBehaviour
{
    public W2_PlayerMovement playerMovementScript;
    public W2_RocketBarrageSystem rocketBarrageSystemScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovementScript = FindAnyObjectByType<W2_PlayerMovement>();
        rocketBarrageSystemScript = FindAnyObjectByType<W2_RocketBarrageSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rocketBarrageSystemScript.numberOfRockets < rocketBarrageSystemScript.maxNumberOfRockets)
        {
            if((this.gameObject.transform.position - playerMovementScript.player.position).magnitude < 1.5f)
            {
                rocketBarrageSystemScript.numberOfRockets += 1;
                Destroy(this.gameObject);
            }     
        }
        else
        {
            Debug.Log("Maximum number of rockets reached. Cannot pick up more power-ups.");
        }
        
    }
}
