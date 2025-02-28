using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject canvasMenue;  
    public GameObject canvasOption;  
    public Button optionButton; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            //ToggleCanvas();
        }
    }

   public void ToggleCanvas()
    {
        if (canvasOption != null)
        {
            bool isActive = canvasOption.activeSelf;  
            canvasOption.SetActive(!isActive);  
        }
        if (canvasMenue != null)
        {
            bool isActive = canvasMenue.activeSelf;  
            canvasMenue.SetActive(!isActive);  
        }
    }
}

