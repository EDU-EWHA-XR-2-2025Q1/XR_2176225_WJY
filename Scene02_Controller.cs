using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene02_Controller : MonoBehaviour
{
    public GameObject pickControllerObject;

    public TMP_Text pickText;
    public TMP_Text putText;
    public Button fireButton;

    private int pick;
    private int put;

    void Start()
    {

        if (Time.frameCount == 1)
        {
            PlayerPrefs.SetInt("PickCount", 0);
            PlayerPrefs.SetInt("PutCount", 0);

            PlayerPrefs.SetInt("UsedCount", 0);

            pickControllerObject.GetComponent<HW04_WJY_Pick_Controller>().ResetPickCount();
        }

        pick = PlayerPrefs.GetInt("PickCount", 0);
        put = PlayerPrefs.GetInt("PutCount", 0);

        UpdateUI();
    }

    void Update()
    {
        if (Time.frameCount == 1)
        {
            PlayerPrefs.SetInt("PickCount", 0);
            PlayerPrefs.SetInt("PutCount", 0);

            pickControllerObject.GetComponent<HW04_WJY_Pick_Controller>().ResetPickCount();
        }
    }


    void UpdateUI()
    {
        if (pickText != null) pickText.text = pick.ToString();
        if (putText != null) putText.text = put.ToString();
        if (fireButton != null) fireButton.interactable = (pick > 0);
    }

    public void OnClick_Fire()
    {
        if (pick <= 0) return;

        pick--;
        put++;

        PlayerPrefs.SetInt("PickCount", pick);
        PlayerPrefs.SetInt("PutCount", put);

        UpdateUI();
    }

    public void OnClick_LoadScene(Object SceneObject)
    {
        SceneManager.LoadScene(SceneObject.name);
    }
}
