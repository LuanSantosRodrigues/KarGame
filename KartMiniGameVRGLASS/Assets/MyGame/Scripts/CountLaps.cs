using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountLaps : MonoBehaviour
{
    public int countLaps = 1;
    public LapsUI lapsUI;
    void Update()
    {
        if (countLaps == 4) Debug.Log("Finished race");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            countLaps += 1;
            lapsUI.ChangeLap(countLaps);
        }
    }

}
