using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    private const float PositionThreshold = 0.5f;
    private bool isPlacedCorrectly;

    void Start()
    {
        resetPosition = transform.localPosition;
    }

    void Update()
    {
        if (!isPlacedCorrectly && moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, transform.localPosition.z);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        float distanceX = Mathf.Abs(transform.localPosition.x - correctForm.transform.localPosition.x);
        float distanceY = Mathf.Abs(transform.localPosition.y - correctForm.transform.localPosition.y);

        if (distanceX <= PositionThreshold && distanceY <= PositionThreshold)
        {
            transform.position = correctForm.transform.position;
            isPlacedCorrectly = true;
            GameObject.Find("PointsHandler").GetComponent<WinScript>().AddPoints();
        }
        else
        {
            transform.localPosition = resetPosition;
        }
    }
}
