using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    public GameObject panelSettings;

    public void ONsettings()
    {
        panelSettings.SetActive(true);
    }
    public void OFFsettings()
    {
        panelSettings.SetActive(false);
    }
}
