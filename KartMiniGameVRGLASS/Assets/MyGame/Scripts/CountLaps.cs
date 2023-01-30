using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountLaps : MonoBehaviour
{
    public int countLaps = 1;
    public LapsUI lapsUI;
    public TextMeshProUGUI timeText;
    public CarControll carControll;
    float time = 0f;
    
    void FixedUpdate()
    {
        if (countLaps == 4) Debug.Log("Finished race");
        if (carControll.canMove)
        {
            time += Time.deltaTime;
            timeText.text = getTimeString(time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Player"))
        {
            countLaps ++;
            Debug.Log(countLaps);
            lapsUI.ChangeLap(countLaps);
            time = 0;
            timeText.text = time.ToString();
        }
    }

    string getTimeString(float time)
    {
        int timeInt = (int)(time);
        int minutes = timeInt / 60;
        int seconds = timeInt % 60;
        float fraction = (time * 100) % 100;
        if (fraction > 99) fraction = 99;
        return string.Format("{0}:{1:00}:{2:00}", minutes, seconds, fraction);
    }

}
