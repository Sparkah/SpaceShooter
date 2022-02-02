using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidOskolki : MonoBehaviour
{
    [SerializeField]
    private GameObject Oskolki;

    [SerializeField]
    private int oskolkiAmount = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        for (int i = 0; i < oskolkiAmount; i++)
        {
            GameObject Oskolok = Instantiate(Oskolki, gameObject.transform.position, Quaternion.identity);
            Oskolok.SendMessage("ChangeSpeed");
        }
    }
}