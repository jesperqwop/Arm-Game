using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float movementSpeed;
    public float sticksSensitivity;
    public GameObject cam;
    float mHdg = 0F;
    float mPitch = 0F;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        float translateX = Input.GetAxis("Horizontal_P1") * sticksSensitivity;
        float translateZ = -Input.GetAxis("Vertical_P1") * sticksSensitivity;
        float rotateX = Input.GetAxis("Horizontal_2_P1") * sticksSensitivity;
        float rotateY = -Input.GetAxis("Vertical_2_P1") * sticksSensitivity;
        Strafe(translateX);
        MoveForwards(translateZ);
        ChangeHeading(rotateX);
        ChangePitch(rotateY);
    }

    void MoveForwards(float aVal)
    {
        Vector3 fwd = transform.forward;
        fwd.y = 0;
        fwd.Normalize();
       // transform.position += aVal * fwd;
        rb.AddForce(fwd * movementSpeed * aVal);
    }

    void Strafe(float aVal)
    {
        // transform.position += aVal * transform.right;
        rb.AddForce(transform.right * movementSpeed * aVal);
    }

    void ChangeHeading(float aVal)
    {
        mHdg += aVal;
        WrapAngle(ref mHdg);
        cam.transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }

    void ChangePitch(float aVal)
    {
        mPitch += aVal;
        WrapAngle(ref mPitch);
        cam.transform.localEulerAngles = new Vector3(mPitch, mHdg, 0);
    }

    public static void WrapAngle(ref float angle)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
    }
}
