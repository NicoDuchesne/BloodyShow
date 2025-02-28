using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PipePlaceholder : MonoBehaviour, IDropHandler
{
    public GameObject actualPrefab = null;
    public bool hasTile => ContainsTile();
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<PipePlacement>(out PipePlacement pipePlacement) && !hasTile)
        {
            GameObject pipeObject = Instantiate(pipePlacement.GetPrefab(), transform);
            actualPrefab = pipePlacement.GetPrefab();
            float scaleFactor = this.GetComponent<RectTransform>().rect.size.x;
            pipeObject.GetComponent<SpriteRenderer>().size = this.GetComponent<RectTransform>().rect.size;

            BoxCollider2D[] childColliders = pipeObject.GetComponentsInChildren<BoxCollider2D>();
            foreach (BoxCollider2D child in childColliders)
            {
                child.size *= scaleFactor;
                child.offset *= scaleFactor;
            }

            pipeObject.transform.localPosition = Vector2.zero;
            PipeCounter.Instance.Increment();
        }

        if (eventData.pointerDrag.TryGetComponent<PipeMovement>(out PipeMovement pipeMovement))
        {

            if (pipeMovement.hasTile)
            {
                if (this.hasTile)
                {
                    if (eventData.pointerDrag.gameObject.name != this.gameObject.name)
                    {
                        Transform myTransform = this.GetTileTransform();
                        Transform otherTransform = pipeMovement.GetTileTransform();
                        
                        otherTransform.parent = this.transform;
                        otherTransform.localPosition = Vector2.zero;
                        myTransform.parent = eventData.pointerDrag.transform;
                        myTransform.localPosition = Vector2.zero;

                        ////other prend nous comme parent
                        //eventData.pointerDrag.transform.GetChild(1).parent = this.transform;
                        ////nouveau other repositioné
                        //this.transform.GetChild(2).localPosition = Vector2.zero;
                        ////notre ancien prefab change de parent
                        //this.transform.GetChild(1).parent = eventData.pointerDrag.transform;
                        ////le nouveau prefab dans other est repositionné
                        //eventData.pointerDrag.transform.GetChild(1).localPosition = Vector2.zero;

                        this.GetComponent<RotatePiece>().SwapRotations(eventData.pointerDrag.GetComponent<RotatePiece>());
                        GameObject temp = this.actualPrefab;
                        this.actualPrefab = eventData.pointerDrag.GetComponent<PipePlaceholder>().actualPrefab;
                        eventData.pointerDrag.GetComponent<PipePlaceholder>().actualPrefab = temp;

                    } else
                    {
                        eventData.pointerDrag.GetComponent<RotatePiece>().DecreaseRotation();
                    }
                }
                else
                {
                    Transform otherTransform = pipeMovement.GetTileTransform();
                    otherTransform.parent = this.transform;
                    otherTransform.localPosition = Vector2.zero;

                    //eventData.pointerDrag.transform.GetChild(1).parent = this.transform;
                    //this.transform.GetChild(1).localPosition = Vector2.zero;

                    this.actualPrefab = eventData.pointerDrag.GetComponent<PipePlaceholder>().actualPrefab;
                    eventData.pointerDrag.GetComponent<PipePlaceholder>().actualPrefab = null;

                    this.GetComponent<RotatePiece>().TakeRotation(eventData.pointerDrag.GetComponent<RotatePiece>());
                }

                

            }

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

}
