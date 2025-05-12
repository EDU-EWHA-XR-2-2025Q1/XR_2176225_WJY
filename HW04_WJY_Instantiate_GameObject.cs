using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_WJY_Instantiate_GameObject : MonoBehaviour
{

    public GameObject Target;
    public int cloneCount = 10;

    void Start()
    {
        
        int picked = PlayerPrefs.GetInt("PickCount", 0);
        int used = PlayerPrefs.GetInt("UsedCount", 0);
        int remain;

        if (used == 0)
        {
            remain = Mathf.Max(0, 10 - picked);
        }
        else
        {
            remain = Mathf.Max(0, 10 - (picked + used));
        }

        Instantiate_GameObject(remain);
    }

    void Instantiate_GameObject(int cloneCount)
    {
        for (int i = 0; i < cloneCount; i++)
        {
            Vector3 randomSphere = Random.insideUnitSphere * 0.055f;
            randomSphere.y = 0f;
            Vector3 randomPos = randomSphere;

            float randomAngle = Random.value * 360f;
            Quaternion randomRot = Quaternion.Euler(0, randomAngle, 0);

            GameObject Clone = Instantiate(Target, randomPos, randomRot);

            Clone.SetActive(true);
            Clone.gameObject.name = "Clone-" + string.Format("{0:D4}", i);
            Clone.transform.SetParent(transform);
        }
    }
}
