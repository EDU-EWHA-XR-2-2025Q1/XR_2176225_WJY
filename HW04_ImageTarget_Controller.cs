using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_ImageTarget_Controller : MonoBehaviour
{
    public GameObject bowlObject;
    public Transform bowlAnchor;

    public void OnTargetFound()
    {
        bowlObject.SetActive(true);
        bowlObject.transform.position = bowlAnchor.position;
    }

    public void OnTargetLost()
    {
        bowlObject.SetActive(false);
    }
}
