using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
        {
            Destroy(collision);
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            UIManager.Instance.EndGameCanvas.gameObject.SetActive(true);
            UIManager.Instance.ShowScoreOnGameEnd();
        }
    }
}