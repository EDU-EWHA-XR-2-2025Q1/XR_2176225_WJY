using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HW04_WJY_UI_Controller : MonoBehaviour
{
    public TMP_Text PickCounts;             
    public TMP_Text PutCounts;              


    public void Display_PickCounts(int count)
    {
        PickCounts.text = count.ToString();

        PlayerPrefs.SetInt("PickCount", count);
    }

    public void Display_PutCounts()
    {
        int lastPutCount = int.Parse(PutCounts.text);
        int currentPutCount = lastPutCount + 1;
        PutCounts.text = currentPutCount.ToString();

        PlayerPrefs.SetInt("PutCount", currentPutCount);
    }

    public void Decrease_PickCounts()
    {
        int lastPickCount = int.Parse(PickCounts.text);
        int currentPickCount = lastPickCount - 1;
        PickCounts.text = currentPickCount.ToString();

        PlayerPrefs.SetInt("PickCount", currentPickCount);
    }

    public int GetPickCounts()
    {
        int pickCounts = int.Parse(PickCounts.text);
        return pickCounts;
    }
}
