using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class PlayerLogicMain
{

    // PlayerController
    public static float speed = 0;
    public static float acceleration = 0.05f;
    public static float maxSpeed = 0.08f;
    public static float decelerationSmooth = 0.01f;
    public static float decelerationRate = 1.1f;
    public static float rotateSpeed = 2;

    public static bool forward = false;
    public static bool rotateLeft = false;
    public static bool rotateRight = false;

    public static LaserBeamGun laserBeamGun;
    public static void LaserShot()
    {
        if (Mouse.current.rightButton.wasReleasedThisFrame)
            laserBeamGun.ShootLaser();
    }

    public static BulletGun bulletGun;
    public static void GunShot()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
            SpawnFromPool("Bullet", bulletGun.transform.position, bulletGun.transform.rotation);
    }


    // BulletGun
    public static Dictionary<string, Queue<GameObject>> poolDictionary;

    public static GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log(tag + " не существует");
            return null;
        }

        GameObject Bullet = poolDictionary[tag].Dequeue();
        Bullet.SetActive(true);
        Bullet.transform.SetPositionAndRotation(position, rotation);

        poolDictionary[tag].Enqueue(Bullet);

        return Bullet;
    }
}