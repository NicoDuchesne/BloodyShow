using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeRemove : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<RotatePiece>(out RotatePiece rotation) && ContainsTile(eventData))
        {
            Debug.Log("DETRUIT");
            rotation.ResetRotation();
            

            foreach (Transform child in eventData.pointerDrag.transform)
            {
                if (child.gameObject.name.Length >= 10)
                {
                    if (child.gameObject.name.Substring(0, 10).Equals("prefabPipe"))
                    {
                        
                        Destroy(child.gameObject);
                    }
                }
            }

            eventData.pointerDrag.transform.GetComponent<PipePlaceholder>().actualPrefab = null;
            PipeCounter.Instance.Decrement();
        }

        
    }

    public bool ContainsTile(PointerEventData data)
    {
        foreach (Transform child in data.pointerDrag.transform)
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
}
