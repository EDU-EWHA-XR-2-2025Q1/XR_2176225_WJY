using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_WJY_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0;
    public GameObject UI;

    void Start()
    {
        clickCounter = PlayerPrefs.GetInt("PickCount", 0);
        UI.GetComponent<HW04_WJY_UI_Controller>().Display_PickCounts(clickCounter);
    }

    public void Add_Click(GameObject Clone) 
    {
        clickCounter++;
        print($"{clickCounter} 개의 클론을 클릭했습니다.");
        Destroy(Clone);

        UI.GetComponent<HW04_WJY_UI_Controller>().Display_PickCounts(clickCounter);

        int total = PlayerPrefs.GetInt("TotalPickCount", 0);
        PlayerPrefs.SetInt("TotalPickCount", total + 1);

        PlayerPrefs.SetInt("PickCount", clickCounter);
    }

    public void ResetPickCount()
    {
        clickCounter = 0;
    }
}
