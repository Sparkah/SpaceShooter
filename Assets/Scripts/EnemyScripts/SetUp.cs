using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUp : MonoBehaviour
{

    void Start()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height + Screen.height/10, 0));
    }
}