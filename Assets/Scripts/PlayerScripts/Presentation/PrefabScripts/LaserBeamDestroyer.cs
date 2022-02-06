using UnityEngine;

public class LaserBeamDestroyer : MonoBehaviour
{
    [SerializeField]
    private float time = 2;
    private float timeSinceStart = 0;

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart > time)
        {
            Destroy(gameObject);
        }
    }
}