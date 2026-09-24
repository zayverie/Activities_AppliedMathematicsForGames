using UnityEngine;

public class W3_ShotgunBullet : MonoBehaviour
{
    public Transform player;
    public W3_SceneRestarter sceneRestarterScript;

    [SerializeField] private float speed = 18f;
    [SerializeField] private float hitArea = 1.5f;
    [SerializeField] private float bulletLifetime = 3f;
    public W3_Shotgun shotgunScript;

    void Start()
    {
        if(shotgunScript == null)
        {
            shotgunScript = FindAnyObjectByType<W3_Shotgun>();
        }

        if (player == null)
        {
            W3_Player foundPlayer = FindAnyObjectByType<W3_Player>();
            if (foundPlayer != null)
            {
                player = foundPlayer.transform;
            }
        }

        if (sceneRestarterScript == null)
        {
            sceneRestarterScript = FindAnyObjectByType<W3_SceneRestarter>();
        }
        Destroy(gameObject, bulletLifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        PelletHitCheck();
    }

    private void PelletHitCheck()
    {
        if (shotgunScript != null && !shotgunScript.IsInCone(transform.position))
        {
            Destroy(gameObject);
            return;
        }
        if (player != null && Vector3.Distance(transform.position, player.position) <= hitArea)
        {
            Debug.Log("Player hit by shotgun pellet!");
            Destroy(gameObject);

            if (sceneRestarterScript != null)
            {
                sceneRestarterScript.RestartScene();
            }
        }
    }
}