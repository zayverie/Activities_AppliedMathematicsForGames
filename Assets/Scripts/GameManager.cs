using UnityEngine; 
using UnityEngine.SceneManagement; 
 
public class GameManager : MonoBehaviour 
{ 
    public GameObject player; 
    public Transform[] noGoZones; 
    public Transform finish; 
    public GameObject winUI; 
    public float movementSpeed = 10f; 
    public float timeInTheZone = 0f; 
 
    void Update() 
    { 
        Vector3 playerDirection = new Vector3( 
            Input.GetAxisRaw("Horizontal"), 
            0f, 
            Input.GetAxisRaw("Vertical")); 
 
        player.transform.position += playerDirection.normalized * movementSpeed * Time.deltaTime; 
 
        bool playerInZone = false;

        foreach(Transform noGoZone in noGoZones){ 
            float distanceToZone = (noGoZone.position - player.transform.position).magnitude; 
 
            if(distanceToZone < 5f){ 
                playerInZone = true;
                timeInTheZone += Time.deltaTime; 
                noGoZone.GetComponent<Renderer>().material.color = Color.red; 
                noGoZone.position += Random.insideUnitSphere.normalized * 0.05f; 
 
                if(distanceToZone < 1f || timeInTheZone >= 3f){ 
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
                } 
            }else{ 
                noGoZone.GetComponent<Renderer>().material.color = Color.black; 
            } 
        } 

        if(!playerInZone){
            timeInTheZone = 0f;
        }
 
        if((finish.position - player.transform.position).magnitude < 1.5f){ 
            winUI.SetActive(true); 
        } 
    } 
}