using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : SetUp
{
    [SerializeField]
    private float timeTillInstantiate = 1f;

    [SerializeField]
    private GameObject[] Enemies;

    private Transform gameObj;

    private SetUp setUp;

    void Start()
    {
        setUp = GetComponent<SetUp>();
        gameObj = GetComponent<Transform>();
        StartCoroutine(AsteroidInstantiator());
    }

    IEnumerator AsteroidInstantiator()
    {
        yield return new WaitForSeconds(timeTillInstantiate);
        Instantiate(Enemies[Random.Range(0, Enemies.Length)], Camera.main.ScreenToWorldPoint(new Vector3(Random.Range
            (gameObj.transform.position.x, gameObj.transform.position.x + Screen.width), Screen.height + Screen.height / 10, 10)), Quaternion.identity);
        StartCoroutine(AsteroidInstantiator());
    }
}
