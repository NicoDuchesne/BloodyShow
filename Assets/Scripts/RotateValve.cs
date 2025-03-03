using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateValve : MonoBehaviour, IRotatable
{
    [SerializeField] public int rotation;
    [SerializeField] public int indexPrefab = 0;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject[] courbPrefabs;
    [SerializeField] public bool isCourb;
    [SerializeField] public bool isDouble;
    [HideInInspector] public int counter = 0;
    public bool isEnabled => checkEnabled();
    

    public int GetRotation()
    {
        return -this.rotation;
    }

    public GameObject GetActualPrefab()
    {
        if (isCourb)
        {
            return courbPrefabs[indexPrefab];
        } else
        {
            return prefabs[indexPrefab];
        }
        
    }

    public GameObject GetNextPrefab(GameObject prefab)
    {
        if (rotation == 0)
        {
            return prefab;
        } else
        {
            return changeIndex();
        }
    }

    private GameObject changeIndex()
    {
        if (isCourb)
        {
            if (indexPrefab == 3)
            {
                indexPrefab = 0;
            } else
            {
                indexPrefab++;
            }
            return courbPrefabs[indexPrefab];
        } else
        {
            if (indexPrefab == 0)
            {
                indexPrefab = 1;
            }
            else
            {
                indexPrefab = 0;
            }
            return prefabs[indexPrefab];
        }
        
    }

    public void RefreshSprite()
    {
        int id = 0;
        GameObject valve = null;
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Length >= 10)
            {
                string substring = child.gameObject.name.Substring(0, 10);
                if (substring.Equals("prefabValv"))
                {
                    valve = child.gameObject;
                }
            }
        }
        SpriteRenderer spriteRenderer = valve.GetComponent<SpriteRenderer>();
        ValveSprites sprites = valve.GetComponent<ValveSprites>();

        if (isCourb)
        {
            id = indexPrefab + 2;
        } else
        {
            id = indexPrefab;
        }


        if (isDouble)
        {
            if (rotation == 0)
            {
                if (counter == 0)
                {
                    spriteRenderer.sprite = sprites.doubleDisable[id];
                }
                else if (counter == 1)
                {
                    spriteRenderer.sprite = sprites.doubleMiddle[id];
                }
                else
                {
                    spriteRenderer.sprite = sprites.doubleEnable[id];
                }
            }
            else
            {
                if (counter == 0)
                {
                    spriteRenderer.sprite = sprites.doubleDisableRot[id];
                }
                else if (counter == 1)
                {
                    spriteRenderer.sprite = sprites.doubleMiddleRot[id];
                }
                else
                {
                    spriteRenderer.sprite = sprites.doubleEnableRot[id];
                }
            }
        }
        else
        {
            if (rotation == 0)
            {
                if (counter == 0)
                {
                    spriteRenderer.sprite = sprites.simpleDisable[id];
                }
                else
                {
                    spriteRenderer.sprite = sprites.simpleEnable[id];
                }
            }
            else
            {
                if (counter == 0)
                {
                    spriteRenderer.sprite = sprites.simpleDisableRot[id];
                }
                else
                {
                    spriteRenderer.sprite = sprites.simpleEnableRot[id];
                }
            }
        }

    }

    private bool checkEnabled()
    {
        if (isDouble && counter >= 2)
        {
            return true;
        }

        if (!isDouble && counter >= 1)
        {
            return true;
        }

        return false;
    }




}

