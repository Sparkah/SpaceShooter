using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Vector3 screenTop;
    private Vector3 screenBottom;

    void Start()
    {
        screenTop = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
        screenBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    void Update()
    {
        if (gameObject.transform.position.y >= screenTop.y)
            gameObject.transform.position = new Vector3(transform.position.x, screenBottom.y, 0);
    }
}