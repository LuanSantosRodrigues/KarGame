using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountLaps : MonoBehaviour
{
    public int countLaps = 0;
    public LapsUI lapsUI;
    void Update()
    {
        if (countLaps == 3) Debug.Log("Finished race");
    }

    private void OnTriggerEnter(Collider other)
    {
        countLaps += 1;
        lapsUI.ChangeLap(countLaps);
    }

}
