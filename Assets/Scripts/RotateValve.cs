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
    [SerializeField] private GameObject[] courbPrefabs;
    [SerializeField] bool isCourb;
    [SerializeField] bool isDouble;
    private int counter = 0;
    public bool isEnabled => checkEnabled();
    

    public int GetRotation()
    {
        return -this.rotation;
    }

    public GameObject GetActualPrefab()
    {
        if (isCourb)
        {
            return prefabs[indexPrefab];
        } else
        {
            return courbPrefabs[indexPrefab];
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

    public void refreshSprite()
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
        Sprite sprite = valve.GetComponent<SpriteRenderer>().sprite;
        ValveSprites sprites = valve.GetComponent<ValveSprites>();

        if (isCourb)
        {
            id = indexPrefab + 2;
        } else
        {
            id = indexPrefab;
        }

        if(isCourb)
        {
            if (isDouble)
            {
                if (rotation == 0)
                {
                    if (counter == 0)
                    {
                        sprite = sprites.doubleDisableCourb[id];
                    }
                    else if (counter == 1)
                    {
                        sprite = sprites.doubleMiddleCourb[id];
                    }
                    else
                    {
                        sprite = sprites.doubleEnableCourb[id];
                    }
                }
                else
                {
                    if (counter == 0)
                    {
                        sprite = sprites.doubleDisableRotCourb[id];
                    }
                    else if (counter == 1)
                    {
                        sprite = sprites.doubleMiddleRotCourb[id];
                    }
                    else
                    {
                        sprite = sprites.doubleEnableRotCourb[id];
                    }
                }
            }
            else
            {
                if (rotation == 0)
                {
                    if (counter == 0)
                    {
                        sprite = sprites.simpleDisableCourb[id];
                    } else
                    {
                        sprite = sprites.simpleEnableCourb[id];
                    }
                } else
                {
                    if (counter == 0)
                    {
                        sprite = sprites.simpleDisableRotCourb[id];
                    }
                    else
                    {
                        sprite = sprites.simpleEnableRotCourb[id];
                    }
                }
            }
        } else
        {
            if (isDouble)
            {
                if (rotation == 0)
                {
                    if (counter == 0)
                    {
                        sprite = sprites.doubleDisable[id];
                    }
                    else if (counter == 1)
                    {
                        sprite = sprites.doubleMiddle[id];
                    }
                    else
                    {
                        sprite = sprites.doubleEnable[id];
                    }
                }
                else
                {
                    if (counter == 0)
                    {
                        sprite = sprites.doubleDisableRot[id];
                    }
                    else if (counter == 1)
                    {
                        sprite = sprites.doubleMiddleRot[id];
                    }
                    else
                    {
                        sprite = sprites.doubleEnableRot[id];
                    }
                }
            }
            else
            {
                if (rotation == 0)
                {
                    if (counter == 0)
                    {
                        sprite = sprites.simpleDisable[id];
                    }
                    else
                    {
                        sprite = sprites.simpleEnable[id];
                    }
                }
                else
                {
                    if (counter == 0)
                    {
                        sprite = sprites.simpleDisableRot[id];
                    }
                    else
                    {
                        sprite = sprites.simpleEnableRot[id];
                    }
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

