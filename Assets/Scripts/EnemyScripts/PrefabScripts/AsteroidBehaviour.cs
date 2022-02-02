using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    private int asteroidSpeed = 1;

    private void MoveAsteroid(int asteroidSpeed)
    {
        transform.position += asteroidSpeed * -Time.deltaTime * transform.up;
        if (gameObject.transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30, 31));
    }

    public void ChangeSpeed()
    {
        asteroidSpeed*=Random.RandomRange(1,4);
        MoveAsteroid(asteroidSpeed);
    }

    void Update()
    {
        MoveAsteroid(asteroidSpeed);
    }
}