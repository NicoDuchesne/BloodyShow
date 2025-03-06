using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CatBin : MonoBehaviour, IDropHandler
{
    [SerializeField] public Sprite closed;
    [SerializeField] public Sprite open;
    private SpriteRenderer spriteRenderer;

    private static CatBin instance = null;
    public static CatBin Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void OpenMouth()
    {
        GetComponentInChildren<Image>().sprite = open;
    }

    public void CloseMouth()
    {
        GetComponentInChildren<Image>().sprite = closed;
    }

    public GameObject returnGO()
    {
        return this.gameObject;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent<RotatePiece>(out RotatePiece rotation) && ContainsTile(eventData))
        {
            Debug.Log("DETRUIT");
            rotation.ResetRotation();

            //Easter EGG
            AchievementManager.UnlockTutorial8Achievement();


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

        //Faire miaulements


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
