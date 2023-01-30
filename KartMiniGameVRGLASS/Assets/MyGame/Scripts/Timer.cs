using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int startCount = 3;
    public TextMeshProUGUI timerText;
    void Start()
    {
        timerText.text = startCount.ToString();
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1f);
        startCount -= 1;
        timerText.text = startCount.ToString();
        if (startCount > 0)
        {
            StartCoroutine(StartTimer());
        }
        else
        {
            timerText.gameObject.SetActive(false);
        }
    }
}
