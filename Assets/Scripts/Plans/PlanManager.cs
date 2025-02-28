using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanManager : MonoBehaviour
{
    [SerializeField] private int startingPlan;
    [SerializeField] private GameObject[] plans;
    [SerializeField] private GameObject ButtonLeft;
    [SerializeField] private GameObject ButtonRight;
    private int actualIndex;
    private GameObject actualPlan;

    private void Start()
    {
        ChangeActualPlan(startingPlan);
        DisplayButtons();
    }

    private void ChangeActualPlan(int index)
    {
        if (!IsInBounds(index)) {
            Debug.Log("Error at ChangeActualPlan function : given index is out of bounds");
            return;
        }

        actualIndex = index;
        actualPlan = plans[index];

        DisplayButtons();

        Camera.main.transform.position = new Vector3(actualPlan.transform.position.x, actualPlan.transform.position.y, -10);

    }

    private void DisplayButtons()
    {
        if (actualIndex == 0)
        {
            ButtonLeft.SetActive(false);
        } else
        {
            ButtonLeft.SetActive(true);
        }

        if (actualIndex == plans.Length-1)
        {
            ButtonRight.SetActive(false);
        }
        else
        {
            ButtonRight.SetActive(true);
        }
    }

    private bool IsInBounds(int index)
    {
        return index >= 0 || index < plans.Length;
    }

    public void NextPlan()
    {
        ChangeActualPlan(actualIndex + 1);
    }

    public void PreviousPlan()
    {
        ChangeActualPlan(actualIndex - 1);
    }

}
