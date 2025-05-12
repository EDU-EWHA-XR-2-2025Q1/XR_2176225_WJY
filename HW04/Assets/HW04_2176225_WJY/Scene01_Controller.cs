using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Scene01_Controller : MonoBehaviour
{
    public GameObject pickControllerObject;
    public TMP_Text pickText;
    public TMP_Text putText;

    void Start()
    {
        if (Time.frameCount == 1)
        {
            PlayerPrefs.SetInt("PickCount", 0);
            PlayerPrefs.SetInt("PutCount", 0);

            PlayerPrefs.SetInt("UsedCount", 0);
            PlayerPrefs.SetInt("TotalCount", 0);

            pickControllerObject.GetComponent<HW04_WJY_Pick_Controller>().ResetPickCount();
        }

        int pick = PlayerPrefs.GetInt("PickCount", 0);
        int put = PlayerPrefs.GetInt("PutCount", 0);

        if (pickText != null) pickText.text = pick.ToString();
        if (putText != null) putText.text = put.ToString();
    }

    
    void Update()
    {
        if (Time.frameCount == 1)
        {
            PlayerPrefs.SetInt("PickCount", 0);
            PlayerPrefs.SetInt("PutCount", 0);

            PlayerPrefs.SetInt("UsedCount", 0);
            PlayerPrefs.SetInt("TotalCount", 0);

            pickControllerObject.GetComponent<HW04_WJY_Pick_Controller>().ResetPickCount();
        }
    }
    

    public void OnClick_LoadScene(Object SceneObject)
    {
        Debug.Log(SceneObject.name);
        SceneManager.LoadScene(SceneObject.name);
    }
}