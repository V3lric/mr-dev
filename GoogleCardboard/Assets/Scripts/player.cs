using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class player : MonoBehaviour
{
    //Matt's modified code
    public Transform rotateAxis;
    public Transform vrCam;
    public float lookAngle,speed,rotateSpeed = 0f;
    public bool movingLeft,movingRight = false;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotationZ = (vrCam.transform.eulerAngles.z < 180f) ? vrCam.transform.eulerAngles.z : vrCam.transform.eulerAngles.z - 360;

        if (rotationZ > 25f && rotationZ < 90f)
        {
            movingLeft = true;
            movingRight = false;
            Debug.Log("Moving Left");
        }
        else if (rotationZ < -25f && rotationZ > -90f)
        {
            movingRight = true;
            movingLeft = false;
            Debug.Log("Moving Right");
        }
        else
        {
            movingLeft = false;
            movingRight = false;
            Debug.Log("Not moving left or right");
        }


        if (movingLeft)
        {
            Vector3 forward = vrCam.TransformDirection(Vector3.left);
            //vrCam.LookAt(rotateAxis);
            transform.RotateAround(rotateAxis.transform.position, Vector3.up, rotateSpeed * Time.deltaTime);
            characterController.SimpleMove(forward * speed);
        }

        else if (movingRight)
        {
            Vector3 forward = vrCam.TransformDirection(Vector3.right);
            transform.RotateAround(rotateAxis.transform.position, Vector3.down, rotateSpeed * Time.deltaTime);
            characterController.SimpleMove(forward * speed);
        }
    }
}
