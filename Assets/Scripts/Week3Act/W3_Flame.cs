using UnityEngine;
using UnityEngine.SceneManagement;

public class W3_Flame : MonoBehaviour
{
    public Transform player;
    public W3_FlameShooter flameShooterScript;
    public W3_SceneRestarter sceneRestarterScript;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float hitArea = 1.5f;
    [SerializeField] private float flameLifetime = 5f;

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

        Destroy(gameObject, flameLifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        HitOrOutsideCone();
    }

    private void HitOrOutsideCone()
    {
        if (flameShooterScript != null && !flameShooterScript.IsInCone(transform.position))
        {
            Destroy(gameObject);
            return;
        }

        if (player != null && (transform.position - player.position).sqrMagnitude <= hitArea)
        {
            Debug.Log("Player hit by projectile!");
            Destroy(gameObject);
            sceneRestarterScript.RestartScene();
        }
    }
}