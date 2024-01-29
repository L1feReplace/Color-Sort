using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private int PointsToWin { get; set; }
    private int CurrentPoints { get; set; }
    public GameObject fruitsContainer;

    // Start is called before the first frame update
    void Start()
    {
        Transform fruitsContainerTransform = fruitsContainer.transform;

        if (fruitsContainerTransform != null)
        {
            PointsToWin = fruitsContainerTransform.childCount;
        }
        else
        {
            PointsToWin = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentPoints >= PointsToWin)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints()
    {
        CurrentPoints++;
    }
}
