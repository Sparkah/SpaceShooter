using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = PlayerLogicMain.speed;
    [SerializeField]
    private float acceleration = PlayerLogicMain.acceleration;
    [SerializeField]
    private float maxSpeed = PlayerLogicMain.maxSpeed;
    [SerializeField]
    private float decelerationSmooth = PlayerLogicMain.decelerationSmooth;
    [SerializeField]
    private float decelerationRate = PlayerLogicMain.decelerationRate;
    [SerializeField]
    private float rotateSpeed = PlayerLogicMain.rotateSpeed;

    private bool forward = PlayerLogicMain.forward;
    private bool rotateLeft = PlayerLogicMain.rotateLeft;
    private bool rotateRight = PlayerLogicMain.rotateRight;

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
        PlayerLogicMain.GunShot();
    }

    public void LaserShot()
    {
        PlayerLogicMain.LaserShot();
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