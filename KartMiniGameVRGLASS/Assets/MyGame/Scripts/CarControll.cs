using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarControll : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }
    [Serializable]
    public struct Wheel 
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    [SerializeField] private float maxAcceleration = 30.0f;
    [SerializeField] private float brakeAcceleration = 50.0f;

    [SerializeField] private float turnSensitivy = 1.0f;
    [SerializeField] private float maxSteerAngle = 30.0f;

    [SerializeField] private Vector3 centerOfMass;


    public List<Wheel> wheels;

    float moveInputs;
    float steerInputs;

    private Rigidbody carRb;

    private void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = centerOfMass;
    }
    private void Update()
    {
        GetInputs();
    }
    private void FixedUpdate()
    {
        MoveCar();
        SteerCar();
        AnimatedWheels();
        BrakeCar();
    }


    void GetInputs() 
    {
        moveInputs = Input.GetAxis("Vertical");
        steerInputs = Input.GetAxis("Horizontal");
    }

    void MoveCar() 
    {
        foreach (var wheel in wheels) 
        {
            if (wheel.axel == Axel.Rear)
            {
                wheel.wheelCollider.motorTorque = moveInputs * 1000 * maxAcceleration * Time.deltaTime;
            }
            
        }
    }

    void SteerCar() 
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front) 
            {
                var steerAngleVar = steerInputs * turnSensitivy * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, steerAngleVar, 0.6f);
            }
        }
    }

    void BrakeCar() 
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void AnimatedWheels() 
    {
        foreach (var wheel in wheels) 
        {
            Quaternion rot;
            Vector3 pos;

            wheel.wheelCollider.GetWorldPose(out pos, out rot);

            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
}
