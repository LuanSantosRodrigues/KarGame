using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float lookSpeed = 10f;
    [SerializeField] private float followSpeed = 10f;

    [SerializeField] private Vector3 offSet;

    private void Update()
    {
        LookAt();
        FollowMe();

        if (Input.GetMouseButton(0)) Debug.Log("Dir");
    }
    void LookAt() 
    {
        Vector3 lookDir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDir, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    void FollowMe() 
    {
        Vector3 targetPos = target.position + (target.forward * offSet.z + target.right * offSet.x + target.up * offSet.y);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
}
