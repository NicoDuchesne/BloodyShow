using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipeClick : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas layoutCanvas;
    [SerializeField] private GameObject prefabPipe;
    private LayoutGroup layoutGroup;
    private RectTransform rectTransform;
    private Vector2 anchorOrigin;
    private CanvasGroup canvasGroup;
    private CameraControls camControls;

    public void Awake()
    {
        layoutGroup = GetComponentInParent<LayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        anchorOrigin = rectTransform.anchoredPosition;
        canvasGroup = GetComponent<CanvasGroup>();
        camControls = GameObject.Find("Main Camera").GetComponent<CameraControls>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
        layoutGroup.enabled = false;
        camControls.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / layoutCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = anchorOrigin;
        layoutGroup.enabled = true;
        camControls.enabled = true;
    }

    public GameObject GetPrefabPipe()
    {
        return prefabPipe;
    }


}
