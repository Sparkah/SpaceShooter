using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float bulletSpeed = 5;


    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * transform.up;
    }
}