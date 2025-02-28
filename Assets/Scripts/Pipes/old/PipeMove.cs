using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipeMove : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 offset;
    private Vector3 origin;
    private CameraControls camControls;
    public bool hasChild => transform.childCount > 0;


    private void Awake()
    {
        camControls = GameObject.Find("Main Camera").GetComponent<CameraControls>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        if (hasChild) {
            transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, -90);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        if(hasChild)
        {
            origin = transform.GetChild(0).position;
            offset = transform.GetChild(0).position - MouseWorldPosition();
            camControls.enabled = false;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        if (hasChild)
        {
            transform.GetChild(0).position = MouseWorldPosition() + offset;
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        if (hasChild)
        {
            transform.GetChild(0).position = origin;
        }
        camControls.enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.GetChild(0).position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }


}
