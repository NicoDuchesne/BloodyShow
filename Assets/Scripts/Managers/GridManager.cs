using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject grid;
    [SerializeField] public GameObject end;
    private bool isInitialized = false;
    private Vector2 gridSize;

    public void Awake()
    {
        if (GameObject.Find("GDmanager") == null)
        {
            gridSize = grid.GetComponent<GridLayoutGroup>().cellSize;

            foreach (Transform child in grid.transform)
            {
                GameObject childGO = child.gameObject;

                if (childGO.TryGetComponent<RotateValve>(out RotateValve rotation))
                {
                    GameObject valve = Instantiate(rotation.GetActualPrefab(), child);

                    valve.GetComponent<SpriteRenderer>().size = gridSize;

                    BoxCollider2D[] childColliders = valve.GetComponentsInChildren<BoxCollider2D>();
                    foreach (BoxCollider2D col in childColliders)
                    {
                        col.size *= gridSize.x;
                        col.offset *= gridSize.x;
                    }

                    valve.transform.localPosition = Vector3.zero;
                }
            }
        }

    }

    public void Update()
    {
        if (!isInitialized)
        {
            StartCoroutine(Initialize());
        }

        gridSize = grid.GetComponent<GridLayoutGroup>().cellSize;
    }

    public void StartingPhase()
    {
        resetEnd();

        foreach (Transform child in grid.transform)
        {
            CleanTiles(child);
        }

        foreach (Transform child in grid.transform)
        {
            GameObject childGO = child.gameObject;

            if (childGO.TryGetComponent<RotateValve>(out RotateValve rotateValve))
            {

                GameObject valve = Instantiate(rotateValve.GetActualPrefab(), child);

                valve.GetComponent<SpriteRenderer>().size = gridSize;

                BoxCollider2D[] childColliders = valve.GetComponentsInChildren<BoxCollider2D>();
                foreach (BoxCollider2D col in childColliders)
                {
                    col.size *= gridSize.x;
                    col.offset *= gridSize.x;
                }

                valve.transform.localPosition = Vector3.zero;
            }

            if (childGO.TryGetComponent<RotatePiece>(out RotatePiece rotatePiece))
            {
                if (childGO.GetComponent<PipePlaceholder>().actualPrefab != null)
                {
                    PipePlaceholder pipePlaceholder = childGO.GetComponent<PipePlaceholder>();
                    //GameObject newPrefab = rotatePiece.GetNextPrefab(pipePlaceholder.actualPrefab);
                    GameObject pipe = Instantiate(pipePlaceholder.actualPrefab, child);
                    //pipePlaceholder.actualPrefab = newPrefab;

                    pipe.GetComponent<SpriteRenderer>().size = gridSize;
                    rotatePiece.UpdateSprite();

                    BoxCollider2D[] childColliders = pipe.GetComponentsInChildren<BoxCollider2D>();
                    foreach (BoxCollider2D col in childColliders)
                    {
                        col.size *= gridSize.x;
                        col.offset *= gridSize.x;
                    }

                    pipe.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    public void NextPhase()
    {
        resetEnd();

        foreach (Transform child in grid.transform)
        {
            CleanTiles(child);
        }

        foreach (Transform child in grid.transform)
        {
            GameObject childGO = child.gameObject;

            if (childGO.TryGetComponent<RotateValve>(out RotateValve rotateValve)) {

                GameObject valve = Instantiate(rotateValve.GetNextPrefab(rotateValve.GetActualPrefab()), child);

                valve.GetComponent<SpriteRenderer>().size = gridSize;

                BoxCollider2D[] childColliders = valve.GetComponentsInChildren<BoxCollider2D>();
                foreach (BoxCollider2D col in childColliders)
                {
                    col.size *= gridSize.x;
                    col.offset *= gridSize.x;
                }

                valve.transform.localPosition = Vector3.zero;
            }

            if (childGO.TryGetComponent<RotatePiece>(out RotatePiece rotatePiece))
            {
                if (childGO.GetComponent<PipePlaceholder>().actualPrefab != null)
                {
                    PipePlaceholder pipePlaceholder = childGO.GetComponent<PipePlaceholder>();
                    GameObject newPrefab = rotatePiece.GetNextPrefab(pipePlaceholder.actualPrefab);
                    GameObject pipe = Instantiate(rotatePiece.GetNextPrefab(childGO.GetComponent<PipePlaceholder>().actualPrefab), child);
                    pipePlaceholder.actualPrefab = newPrefab;

                    pipe.GetComponent<SpriteRenderer>().size = gridSize;

                    BoxCollider2D[] childColliders = pipe.GetComponentsInChildren<BoxCollider2D>();
                    foreach (BoxCollider2D col in childColliders)
                    {
                        col.size *= gridSize.x;
                        col.offset *= gridSize.x;
                    }

                    pipe.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    IEnumerator Initialize()
    {
        isInitialized = true;
        yield return new WaitForSeconds(0.5f);

        foreach (Transform child in grid.transform)
        {

            if (child.GetComponent<RotateValve>() != null)
            {
                child.gameObject.tag = "Untagged";
                child.GetChild(0).GetChild(0).gameObject.tag = "PipeNO";
            }
        }
    }

    private void resetEnd()
    {
        BoxCollider2D[] childColliders = end.GetComponentsInChildren<BoxCollider2D>();
        foreach (BoxCollider2D col in childColliders)
        {
            col.enabled = true;
        }
        end.tag = "Untagged";
        end.transform.GetChild(0).GetChild(0).gameObject.tag = "PipeNO";
        end.transform.GetChild(0).gameObject.tag = "Pipe";
    }

    public void CleanTiles(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name.Length >= 10)
            {
                string substring = child.gameObject.name.Substring(0, 10);
                if (substring.Equals("prefabPipe") || substring.Equals("prefabValv"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }



}
