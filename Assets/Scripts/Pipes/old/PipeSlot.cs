using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PipeSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag.GetComponent<PipeClick>() != null)
        {
            if (transform.childCount > 0)
            {
                return;
            }

            GameObject pipeObject = Instantiate(eventData.pointerDrag.GetComponent<PipeClick>().GetPrefabPipe(), transform);
            pipeObject.transform.localPosition = Vector2.zero;
            
        }

        if (eventData.pointerDrag.GetComponent<PipeMove>() != null)
        {

            if(eventData.pointerDrag.GetComponent<PipeMove>().hasChild)
            {
                if (transform.childCount > 0)
                {
                    eventData.pointerDrag.transform.GetChild(0).parent = this.transform;
                    this.transform.GetChild(1).localPosition = Vector2.zero;
                    this.transform.GetChild(0).parent = eventData.pointerDrag.transform;
                    eventData.pointerDrag.transform.GetChild(0).localPosition = Vector2.zero;
                } else
                {
                    eventData.pointerDrag.transform.GetChild(0).parent = this.transform;
                    this.transform.GetChild(0).localPosition = Vector2.zero;
                }
                
            }

        }
    }
}
