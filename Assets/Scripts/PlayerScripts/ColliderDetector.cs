using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision);
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        UIManager.Instance.EndGameCanvas.gameObject.SetActive(true);
        UIManager.Instance.ShowScoreOnGameEnd();
    }
}