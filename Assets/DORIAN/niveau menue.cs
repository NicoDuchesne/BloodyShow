using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NiveauMenu : MonoBehaviour
{
    public GameObject canvasNiveau;
    public GameObject canvasMenue;

   public void ToggleCanvas()
    {
        if (canvasNiveau != null)
        {
            bool isActive = canvasNiveau.activeSelf;
            canvasNiveau.SetActive(!isActive);  
        }
        if (canvasMenue != null)
        {
            bool isActive = canvasMenue.activeSelf;
            canvasMenue.SetActive(!isActive);
        }
    }
}

