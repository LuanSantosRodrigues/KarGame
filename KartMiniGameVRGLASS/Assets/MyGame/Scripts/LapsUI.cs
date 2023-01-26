using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapsUI : MonoBehaviour
{
    public TextMeshProUGUI lapsNumberText;
    public void ChangeLap(int count)
    {
        lapsNumberText.text = count.ToString() + "/3";
    }
}
