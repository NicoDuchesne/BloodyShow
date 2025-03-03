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

        RemoveManager.Instance.EnableZones();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        transform.position = MouseWorldPosition() + offset;

        if (eventData.hovered.Contains(RemoveManager.Instance.topZone.gameObject) ||
            eventData.hovered.Contains(RemoveManager.Instance.leftZone.gameObject) ||
            eventData.hovered.Contains(RemoveManager.Instance.rightZone.gameObject) ||
            eventData.hovered.Contains(RemoveManager.Instance.botZone.gameObject))
        {
            gameObject.GetComponent<Image>().color = new Color(255 / 255f, 80 / 255f, 80 / 255f, 255 / 255f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        transform.position = origin;
        audioSource.PlayOneShot(sound);   // sound for placement pipes

        RemoveManager.Instance.DisableZones();
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
