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

    [SerializeField] private TextMeshProUGUI cauntTimeLaps1;
    [SerializeField] private TextMeshProUGUI cauntTimeLaps2;
    [SerializeField] private TextMeshProUGUI cauntTimeLaps3;
    [SerializeField] private float[] timeSaveLap;



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
            SaveTimeLaps();
            time = 0;
            timeText.text = time.ToString();

            
            

        }
    }

    public void SaveTimeLaps()
    {
        if (countLaps == 1) cauntTimeLaps1.text = getTimeString(time);
        if (countLaps == 2) cauntTimeLaps2.text = getTimeString(time);
        if (countLaps == 3) cauntTimeLaps3.text = getTimeString(time);

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
