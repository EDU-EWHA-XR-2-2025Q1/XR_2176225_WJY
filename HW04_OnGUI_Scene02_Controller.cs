using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class HW04_OnGUI_Scene02_Controller : MonoBehaviour
{
    [Range(10, 150)]
    public int fontSize = 30;
    public Color color = new Color(.0f, .0f, .0f, 1.0f);
    public float width, height;
    string message;

    public GameObject fireButton;
    public GameObject aimPoint;

    public Button Fire_Button;
    public GameObject UI;

    public void OnTarget_Found(string _s)
    {
        message = _s;

        fireButton.SetActive(true);
        aimPoint.SetActive(true);

        int pickCounts = UI.GetComponent<HW04_WJY_UI_Controller>().GetPickCounts();
        if (pickCounts <= 0)
        {
            Fire_Button.interactable = false;
        }
    }

    public void OnTarget_Lost(string _s)
    {
        message = _s;

        fireButton.SetActive(false);
        aimPoint.SetActive(false);
    }



    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal.textColor = color;
        style.alignment = TextAnchor.UpperLeft;

        GUI.Label(new Rect(0, 0, width, height), message, style);
    }

    void Update()
    {
        int pickCounts = UI.GetComponent<HW04_WJY_UI_Controller>().GetPickCounts();
        if (pickCounts <= 0)
        {
            Fire_Button.interactable = false;
        }
    }
}
