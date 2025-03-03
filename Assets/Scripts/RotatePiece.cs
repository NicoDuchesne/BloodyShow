using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RotatePiece : MonoBehaviour, IPointerClickHandler, IRotatable
{
    [SerializeField] public TextMeshProUGUI counterDisplay;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject[] prefabsLine;

    public int counter = 0;
    private int rotation = 0;



    public virtual void OnPointerClick(PointerEventData eventData)
    {

        if (ContainsTile(transform))
        {
            counter++;
            UpdateCounterDisplay();
            UpdateRotation();
            UpdateSprite();

            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "Niveau_TUTO_2")
            {
                if (counter > 0)
                {
                    Debug.Log("TUTO 4 OFF");
                    TutoManager.OnActiveTuto4 = false;
                }
            }
        }
    }

    public GameObject GetNextPrefab(GameObject prefab)
    {
        if(counter == 0)
        {
            return prefab;
        }

        int index = 0;
        PipeLine p = prefab.GetComponent<PipeLine>();
        if (p.isLine) {
            
            foreach (GameObject child in prefabsLine)
            {
                
                if (prefab == child)
                {
                    break;
                }
                index++;
            }

            return prefabsLine[(index + counter) % 2];
        } else
        {
            foreach (GameObject child in prefabs)
            {
                if (prefab == child)
                {
                    break;
                }
                index++;
            }

            return prefabs[(index + counter) % 4];
        }
        
    }



    private void UpdateCounterDisplay()
    {
        if (counter % 4 == 0)
        {
            counterDisplay.text = "";
        } else
        {
            counterDisplay.text = $"{counter % 4}";
        }
    }

    private void UpdateRotation()
    {
        rotation = -90 * (counter%4);
    }

    public void UpdateSprite()
    {
        GameObject tile = GetTile(transform);
        PipeLine pipeLine = tile.GetComponent<PipeLine>();
        SpriteRenderer spriteRenderer = tile.GetComponent<SpriteRenderer>();

        if (counter % 4 == 0)
        {
            spriteRenderer.sprite = pipeLine.orignialSprite;
        }
        else
        {
            spriteRenderer.sprite = pipeLine.rotatedSprite;
        }

    }


    public void SwapRotations(RotatePiece other)
    {
        int tempCounter = other.GetCounter();
        int tempRotation = other.GetRotation();

        other.SetCounter(this.counter);
        other.SetRotation(this.rotation);

        this.SetCounter(tempCounter);
        this.SetRotation(tempRotation);

        this.UpdateCounterDisplay();
        other.UpdateCounterDisplay();
    }

    public void TakeRotation(RotatePiece other)
    {
        this.SetCounter(other.GetCounter());
        this.SetRotation(other.GetRotation());

        this.UpdateCounterDisplay();
        other.ResetRotation();
    }

    public void DecreaseRotation()
    {
        counter--;
        UpdateCounterDisplay();
        UpdateRotation();
    }

    public int GetCounter()
    {
        return this.counter;
    }

    public int GetRotation()
    {
        return this.rotation;
    }

    public void SetCounter(int counter)
    {
        this.counter = counter;
    }

    public void SetRotation(int rotation)
    {
        this.rotation = rotation;
    }

    public void ResetRotation()
    {
        this.rotation = 0;
        this.counter = 0;
        UpdateCounterDisplay();
    }

    public bool ContainsTile(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name.Length >= 10)
            {
                string substring = child.gameObject.name.Substring(0, 10);
                if (substring.Equals("prefabPipe") || substring.Equals("prefabValv"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public GameObject GetTile(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name.Length >= 10)
            {
                string substring = child.gameObject.name.Substring(0, 10);
                if (substring.Equals("prefabPipe"))
                {
                    return child.gameObject;
                }
            }
        }
        return null;
    }
}
