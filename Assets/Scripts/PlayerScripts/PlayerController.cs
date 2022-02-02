using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = MainLogic.speed;
    [SerializeField]
    private float acceleration = MainLogic.acceleration;
    [SerializeField]
    private float maxSpeed = MainLogic.maxSpeed;
    [SerializeField]
    private float decelerationSmooth = MainLogic.decelerationSmooth;
    [SerializeField]
    private float decelerationRate = MainLogic.decelerationRate;
    [SerializeField]
    private float rotateSpeed = MainLogic.rotateSpeed;

    private bool forward = MainLogic.forward;
    private bool rotateLeft = MainLogic.rotateLeft;
    private bool rotateRight = MainLogic.rotateRight;

    private LaserBeamGun laserBeamGun;
    private BulletGun bulletGun;

    private void Start()
    {
        laserBeamGun = GetComponentInChildren<LaserBeamGun>();
        bulletGun = GetComponentInChildren<BulletGun>();
    }

    public void RotateInput()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
            rotateLeft = true;

        if (Keyboard.current.aKey.wasReleasedThisFrame)
            rotateLeft = false;

        if (Keyboard.current.dKey.wasPressedThisFrame)
            rotateRight = true;

        if (Keyboard.current.dKey.wasReleasedThisFrame)
            rotateRight = false;
    }

    public void MoveInput()
    {
        if (Keyboard.current.wKey.wasPressedThisFrame)
            forward = true;

        if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            forward = false;
            StartCoroutine(Decelerate());
        }
    }

    private void FixedUpdate()
    {
        if (forward == true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
            if (speed < maxSpeed)
                speed += acceleration;
        }

        if (rotateLeft)
            transform.Rotate(new Vector3(0, 0, rotateSpeed));

        if (rotateRight)
            transform.Rotate(new Vector3(0, 0, -rotateSpeed));
    }

    public void GunShot()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
            bulletGun.SpawnFromPool("Bullet", bulletGun.transform.position, bulletGun.transform.rotation);
    }

    public void LaserShot()
    {
        if (Mouse.current.rightButton.wasReleasedThisFrame)
            laserBeamGun.ShootLaser();
    }

    IEnumerator Decelerate()
    {
        yield return new WaitForSeconds(decelerationSmooth);
        transform.position = new Vector3(transform.position.x, transform.position.y + speed / decelerationRate * Time.deltaTime, transform.position.z);
        speed /= decelerationRate;
        if (speed > 0.1f)
            StartCoroutine(Decelerate());
    }
}