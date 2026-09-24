using UnityEngine;

public class W3_SniperBullet : MonoBehaviour
{
    public Transform player;
    public W3_Sniper sniperScript;
    public W3_SceneRestarter sceneRestarterScript;

    [SerializeField] private float speed = 50f;
    [SerializeField] private float hitArea = 1.5f;
    [SerializeField] private float bulletLifetime = 5f;

    void Start()
    {
        if (sniperScript == null)
        {
            sniperScript = FindAnyObjectByType<W3_Sniper>();
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
        SniperHitCheck();
    }

    private void SniperHitCheck()
    {
        if (sniperScript != null && !sniperScript.InSight(transform.position))
        {
            Destroy(gameObject);
            return;
        }

        if (player != null && (transform.position - player.position).sqrMagnitude <= hitArea)
        {
            Debug.Log("Player hit by sniper projectile!");
            Destroy(gameObject);

            if (sceneRestarterScript != null)
            {
                sceneRestarterScript.RestartScene();
            }
        }
    }
}