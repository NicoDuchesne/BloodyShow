using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateValve : MonoBehaviour, IRotatable
{
    [SerializeField] private int rotation = 90;
    [SerializeField] public int indexPrefab = 0;
    [SerializeField] private GameObject[] prefabs;

    public int GetRotation()
    {
        return -this.rotation;
    }

    public GameObject GetActualPrefab()
    {
        return prefabs[indexPrefab];
    }

    public GameObject GetNextPrefab(GameObject prefab)
    {
        if (rotation == 0 || rotation == 180) {
            return prefab;
        } else
        {
            changeIndex();
            return prefabs[indexPrefab];
        }
    }

    private void changeIndex()
    {
        if (indexPrefab == 0)
        {
            indexPrefab = 1;
        } else
        {
            indexPrefab = 0;
        }
    }

    

}

