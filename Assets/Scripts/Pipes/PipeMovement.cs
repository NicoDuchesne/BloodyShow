using Codice.CM.Client.Differences;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipeMovement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 offset;
    private Vector3 origin;
    public bool hasTile => ContainsTile();

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(hasTile)
        {
            Debug.Log("OnBeginDrag");
            origin = transform.GetChild(transform.childCount-1).position;
            offset = transform.GetChild(transform.childCount - 1).position - MouseWorldPosition();
            GetComponent<RotatePiece>().counterDisplay.enabled = false;
            RemoveManager.Instance.EnableZones();
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (hasTile)
        {
            Debug.Log("OnDrag");
            transform.GetChild(transform.childCount - 1).position = MouseWorldPosition() + offset;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<RotatePiece>().counterDisplay.enabled = true;
        RemoveManager.Instance.DisableZones();

        if (hasTile)
        {
            Debug.Log("OnEndDrag");
            transform.GetChild(transform.childCount - 1).position = origin;
            
        }
    }

    public bool ContainsTile()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Length >= 10)
            {
                if (child.gameObject.name.Substring(0, 10).Equals("prefabPipe"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Transform GetTileTransform()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Length >= 10)
            {
                if (child.gameObject.name.Substring(0, 10).Equals("prefabPipe"))
                {
                    return child;
                }
            }
        }
        return null;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.GetChild(1).position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

}
