using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControll : MonoBehaviour
{
    [SerializeField] private WheelCollider front_driveCol;
    [SerializeField] private WheelCollider front_passCol;
    [SerializeField] private WheelCollider back_driveCol;
    [SerializeField] private WheelCollider back_passCol;

    [SerializeField] private Transform frontDRiver, frontPass;
    [SerializeField] private Transform backDRiver, backPass;

    public float steerAngle = 25.0f;
    public float motorForce = 1500f;
    public float steerAlgleResult;

    private float horizontal;
    private float vertical;

    private void FixedUpdate()
    {
        Inputs();
        DriveCar();
        SteerCar();
        BreakCar();

        updateWheelPos(front_driveCol, frontDRiver);
        updateWheelPos(front_passCol, frontPass);
        updateWheelPos(back_driveCol, backDRiver);
        updateWheelPos(back_passCol, backPass);
    }

    void Inputs() 
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void DriveCar() 
    {
        back_driveCol.motorTorque = vertical * motorForce;
        back_passCol.motorTorque = vertical * motorForce;
    }
    void SteerCar() 
    {
        steerAlgleResult = steerAngle * horizontal;
        front_driveCol.steerAngle = steerAlgleResult;
        front_passCol.steerAngle = steerAlgleResult;
    }
    void BreakCar() 
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            back_driveCol.motorTorque = vertical * motorForce * -1;
            back_passCol.motorTorque = vertical * motorForce * -1;
        }
    }

    void updateWheelPos(WheelCollider wCol, Transform wTrans) 
    {
        Vector3 pos = wTrans.position;
        Quaternion rot = wTrans.rotation;

        wCol.GetWorldPose(out pos, out rot);
        wTrans.position = pos;
        wTrans.rotation = rot;
    }



}
