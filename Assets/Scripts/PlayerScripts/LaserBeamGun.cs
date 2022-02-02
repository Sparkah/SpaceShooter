using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamGun : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserBeam;

    private Transform Player;

    private void Start()
    {
        Player = GetComponentInParent<Transform>();
    }

    public void ShootLaser()
    {
        if (UIManager.Instance.currentLaserAmmount > 0)
        {
            UIManager.Instance.currentLaserAmmount -= 1;
            Instantiate(LaserBeam, transform.position, transform.rotation, Player.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision);
    }
}
