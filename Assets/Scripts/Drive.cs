using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour {

    public GameObject backLeft, backRight, fronLeft, frontRight;

    JointMotor mbackLeft, mbackRight, mfronLeft, mfrontRight;
    //  public HingeJoint joinBackLeft,

    public float speed = 255;


    void Start () {
        backLeft.GetComponent<HingeJoint>().useMotor = true;
        backRight.GetComponent<HingeJoint>().useMotor = true;
        fronLeft.GetComponent<HingeJoint>().useMotor = true;
        frontRight.GetComponent<HingeJoint>().useMotor = true;
    }

    // Update is called once per frame
    void Update () {
        float w = Input.GetAxis("Vertical");
        float a = Input.GetAxis("Horizontal");

        TankDrive(w+a,w-a);
    }

    void TankDrive(float left, float right)
    {
        if (left > 1) left = 1;
        if (left < -1) left = -1;
        if (right > 1) right = 1;
        if (right < -1) right = -1;

        if (right != 0)
        {
            mbackRight = backRight.GetComponent<HingeJoint>().motor;
            mfrontRight = frontRight.GetComponent<HingeJoint>().motor;

            mbackRight.force = 10000;
            mbackRight.targetVelocity = right * speed;
            mfrontRight.force = 10000;
            mfrontRight.targetVelocity = right * speed;

            backRight.GetComponent<HingeJoint>().motor = mbackRight;
            frontRight.GetComponent<HingeJoint>().motor = mfrontRight;

        }
        if (left != 0)
        {
            mfronLeft = fronLeft.GetComponent<HingeJoint>().motor;
            mbackLeft = backLeft.GetComponent<HingeJoint>().motor;

            mfronLeft.force = 10000;
            mfronLeft.targetVelocity = left * speed;
            mbackLeft.force = 10000;
            mbackLeft.targetVelocity = left * speed;

            fronLeft.GetComponent<HingeJoint>().motor = mfronLeft;
            backLeft.GetComponent<HingeJoint>().motor = mbackLeft;

        }
    }
}
