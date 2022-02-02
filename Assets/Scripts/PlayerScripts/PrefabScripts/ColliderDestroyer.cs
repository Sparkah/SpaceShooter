using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDestroyer : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        UIManager.Instance.ScoreCounter();
        if(Bullet!=null)
        {
            gameObject.SetActive(false);
        }
    }
}