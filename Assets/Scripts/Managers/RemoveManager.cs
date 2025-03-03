using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveManager : MonoBehaviour
{
    [SerializeField] public Transform topZone;
    [SerializeField] public Transform leftZone;
    [SerializeField] public Transform rightZone;
    [SerializeField] public Transform botZone;

    private static RemoveManager instance = null;
    public static RemoveManager Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

    }

    public void EnableZones()
    {
        topZone.GetChild(0).gameObject.SetActive(true);
        leftZone.GetChild(0).gameObject.SetActive(true);
        rightZone.GetChild(0).gameObject.SetActive(true);
        botZone.GetChild(0).gameObject.SetActive(true);
    }

    public void DisableZones()
    {
        topZone.GetChild(0).gameObject.SetActive(false);
        leftZone.GetChild(0).gameObject.SetActive(false);
        rightZone.GetChild(0).gameObject.SetActive(false);
        botZone.GetChild(0).gameObject.SetActive(false);
    }
}
