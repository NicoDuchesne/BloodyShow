using UnityEngine;
using UnityEngine.EventSystems;

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

        if (eventData.hovered.Contains(RemoveManager.Instance.topZone.gameObject) ||
            eventData.hovered.Contains(RemoveManager.Instance.leftZone.gameObject) ||
            eventData.hovered.Contains(RemoveManager.Instance.rightZone.gameObject)||
            eventData.hovered.Contains(RemoveManager.Instance.botZone.gameObject))
        {
            Debug.Log(GetTileTransform().gameObject.name);
            GetTileTransform().gameObject.GetComponent<SpriteRenderer>().color = new Color(255/255f, 80/255f, 80/255f, 255/255f);
        }
        else
        {
            GetTileTransform().gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
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
