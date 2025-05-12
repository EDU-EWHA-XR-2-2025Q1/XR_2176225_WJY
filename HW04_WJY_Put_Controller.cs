using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HW04_WJY_Put_Controller : MonoBehaviour
{
    public GameObject TargetObjectToThrow;
    public Transform PlayerCamera;
    public GameObject UI;

    public Button fireButton;

    public void Fire()
    {
        int pickCounts = UI.GetComponent<HW04_WJY_UI_Controller>().GetPickCounts();
        if (pickCounts > 0)
        {
            Throw();
            UI.GetComponent<HW04_WJY_UI_Controller>().Decrease_PickCounts();
        }
        else
        {
            fireButton.interactable = false;
            Debug.Log("발사 불가: PickCount가 0입니다.");
        }
    }

    void Update()
    {
        int count = PlayerPrefs.GetInt("PickCounts", 0);
        if (count <= 0)
        {
            fireButton.interactable = false;
        }

        int pickCounts = UI.GetComponent<HW04_WJY_UI_Controller>().GetPickCounts();
        if (pickCounts <= 0)
        {
            fireButton.interactable = false;
        }
    }

    void Throw()
    {
        Vector3 Pos = PlayerCamera.position + PlayerCamera.forward * 0.3f;

        float randomAngleX = Random.value * 360f;
        float randomAngleY = Random.value * 360f;
        float randomAngleZ = Random.value * 360f;
        Quaternion randomRot = Quaternion.Euler(randomAngleX, randomAngleY, randomAngleZ);

        GameObject Clone = Instantiate(TargetObjectToThrow, Pos, randomRot);
        Clone.SetActive(true);
        Clone.GetComponent<Collider>().isTrigger = false;
        Clone.GetComponent<Rigidbody>().useGravity = true;
        Clone.GetComponent<Rigidbody>().AddForce(PlayerCamera.forward * 300f);
        Destroy(Clone, 3);

        int used = PlayerPrefs.GetInt("UsedCount", 0);
        PlayerPrefs.SetInt("UsedCount", used + 1);
    }
}
