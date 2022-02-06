using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Laser") && !collision.CompareTag("Bullet") && !collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            UIManager.Instance.ScoreCounter();
        }
        if(Bullet!=null)
        {
            gameObject.SetActive(false);
        }
    }
}