using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipePlacement : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private GameObject prefabPipe;
    private Vector3 offset;
    private Vector3 origin;

    //Son
    public AudioSource audioSource;
    public AudioClip sound;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        origin = transform.position;
        offset = transform.position - MouseWorldPosition();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = MouseWorldPosition() + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.position = origin;
        AudioSource.PlayClipAtPoint(sound, transform.position); // sound for placement pipes
    }

    private Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    public GameObject GetPrefab()
    {
        return prefabPipe;
    }

}
