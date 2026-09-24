using UnityEngine;
using UnityEngine.SceneManagement;

public class W3_Projectile : MonoBehaviour
{
    public Transform player;
    public W3_FlameShooter flameShooterScript;
    public W3_SceneRestarter sceneRestarterScript;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float hitArea = 1.5f;
    [SerializeField] private float projectileLifetime = 5f;

    void Start()
    {
        if (flameShooterScript == null)
        {
            flameShooterScript = FindAnyObjectByType<W3_FlameShooter>();
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

        Destroy(gameObject, projectileLifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        HitOrOutsideCone();
    }

    private void HitOrOutsideCone()
    {
        // 1. Despawn if outside the shooter's cone
        if (flameShooterScript != null && !flameShooterScript.IsInCone(transform.position))
        {
            Destroy(gameObject);
            return;
        }

        // 2. Despawn and register damage on player hit
        if (player != null && (transform.position - player.position).sqrMagnitude <= hitArea)
        {
            Debug.Log("Player hit by projectile!");
            Destroy(gameObject);
            sceneRestarterScript.RestartScene();
        }
    }
}