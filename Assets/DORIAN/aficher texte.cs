using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class afichertexte : MonoBehaviour
{

    public GameObject canvastexte;
    

    private void Start()
    {
        canvastexte.SetActive(true);
    }

    public void ToggleCanvas()
    {
        
            bool isActive = canvastexte.activeSelf;
            canvastexte.SetActive(!isActive);
        
    }
}
