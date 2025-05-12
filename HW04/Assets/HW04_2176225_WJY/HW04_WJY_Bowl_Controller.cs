using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW04_WJY_Bowl_Controller : MonoBehaviour
{
    public GameObject UI_Controller;

    public Transform centerPoint;
    public float moveRadius = 0.01f;

    private float moveTimer = 0f;
    private float nextMoveTime = 0.5f;

    private bool isActive = false;
    private float initialLocalY;

    
    
    void Start()
    {
        initialLocalY = transform.localPosition.y;
    }



    void OnEnable()
    {
        isActive = true;
        ResetTimer();
    }

    void OnDisable()
    {
        isActive = false;
    }

    void Update()
    {
        if (!isActive) return;

        moveTimer += Time.deltaTime;
        if (moveTimer >= nextMoveTime)
        {
            MoveToRandomPosition();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        moveTimer = 0f;
        nextMoveTime = Random.Range(0.5f, 1.0f);
    }

    void MoveToRandomPosition()
    {
        Vector2 offset2D = Random.insideUnitCircle * moveRadius;

        transform.localPosition = new Vector3(
            offset2D.x,
            initialLocalY,
            offset2D.y
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            UI_Controller.GetComponent<HW04_WJY_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}