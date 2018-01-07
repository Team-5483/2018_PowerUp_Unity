using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balance : MonoBehaviour {
    public HingeJoint hinge;
    // Use this for initialization

    public float min = -10, max = 10;
    public float dampeningForce = 2, dampeningVelocity = 10;
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        JointLimits limits = hinge.limits;
        limits.min = min;
        limits.bounciness = 0;
        limits.max = max;

        hinge.limits = limits;
        hinge.useLimits = true;
        MoveToZero();
    }

    void MoveToZero()
    {
        float angle =  hinge.angle;
        JointMotor motor = hinge.motor;
        float approachSpeed = 1;
        if ((angle < 1 && angle > 0) || (angle > -1 && angle < 0)) approachSpeed = 0.1f;

        if (angle > -0.01)
        {
            motor.force = dampeningForce;
            motor.targetVelocity = -dampeningVelocity * approachSpeed;

        } else if (angle < -0.01)
        {
            motor.force = dampeningForce;
            motor.targetVelocity = dampeningVelocity * approachSpeed;
        }
        hinge.motor = motor;
    }
}
