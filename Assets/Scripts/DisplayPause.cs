using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPause : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    public void DisplayPauseScreen()
    {
        pauseScreen.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HidePauseScreen()
    {
        pauseScreen.transform.GetChild(0).gameObject.SetActive(false);
    }
}
