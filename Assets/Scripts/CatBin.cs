using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.IonicZip;
using UnityEngine;
using UnityEngine.UI;

public class CatBin : MonoBehaviour
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
}
