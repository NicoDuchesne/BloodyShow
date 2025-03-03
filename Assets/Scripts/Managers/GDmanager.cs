using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GDmanager : MonoBehaviour
{
    [Header("GD LEVEL DESIGN")]
    [SerializeField] LevelDesignData ld;

    [Header("REFERENCES")]
    [SerializeField] private GameObject gridSprites;
    [SerializeField] private GameObject prefabWhiteTile;
    [SerializeField] private GameObject prefabBlackTile;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject prefabEmptyTile;
    [SerializeField] private GameObject prefabValveTile;
    [SerializeField] private GameObject prefabBigBlood;
    [SerializeField] private GameObject prefabSmallBloodTop;
    [SerializeField] private GameObject prefabSmallBloodBot;
    [SerializeField] private GameObject prefabSquareBlood;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject prefabArrivee;
    [SerializeField] private GameObject actualJauge;
    [SerializeField] private GameObject prefabEnd;
    [SerializeField] private GridManager gridManager;

    private int maxDimensionX = 960;
    private int maxDimensionY = 600;
    private GameObject jauge;

    private int divDimension;
    private List<(int, int, String)> valvePos;
    private (int, int)[] startPos;
    private (int, int) endPos;


    void Awake()
    {
        TranslateValues();
        SetupMatrixes();
        SetupValves();
        SetupEnd();
        SetupStarts();
        
    }

    private void SetupMatrixes()
    {
        int divX = maxDimensionX / ld.matrixX;
        int divY = maxDimensionY / ld.matrixY;

        if(divX <= divY)
        {
            divDimension = divX;
        } else
        {
            divDimension = divY;
        }

        RectTransform gridSpritesRect = gridSprites.GetComponent<RectTransform>();
        gridSpritesRect.sizeDelta = new Vector2(divDimension* ld.matrixX, divDimension* ld.matrixY);

        GridLayoutGroup gridSpritesLayoutGroup = gridSprites.GetComponent<GridLayoutGroup>();
        gridSpritesLayoutGroup.cellSize = new Vector2(divDimension, divDimension);

        RectTransform gridRect = grid.GetComponent<RectTransform>();
        gridRect.sizeDelta = new Vector2(divDimension * ld.matrixX, divDimension * ld.matrixY);

        GridLayoutGroup gridLayoutGroup = grid.GetComponent<GridLayoutGroup>();
        gridLayoutGroup.cellSize = new Vector2(divDimension, divDimension);

        for (int y = 0; y < ld.matrixY; y++)
        {
            for (int x = 0; x < ld.matrixX; x++)
            {
                if(valvePos.Contains((x,y,"horizontal")))
                {
                    GameObject valveTileGO = Instantiate(prefabValveTile, grid.transform);
                    valveTileGO.GetComponent<RotateValve>().indexPrefab = 1;
                } 
                else if (valvePos.Contains((x,y,"vertical")))
                {
                    GameObject valveTileGO = Instantiate(prefabValveTile, grid.transform);
                    valveTileGO.GetComponent<RotateValve>().indexPrefab = 0;
                }
                else
                {
                    GameObject pipeTileGO = Instantiate(prefabEmptyTile, grid.transform);
                    pipeTileGO.name = "PlaceHolder"+x.ToString()+y.ToString();
                }

                if (x%2 == y%2) 
                {
                    Instantiate(prefabWhiteTile, gridSprites.transform);
                } else
                {
                    Instantiate(prefabBlackTile, gridSprites.transform);
                }
            }
        }
    }

    private void SetupValves()
    {

        foreach (Transform child in grid.transform)
        {
            GameObject childGO = child.gameObject;

            if (childGO.TryGetComponent<RotateValve>(out RotateValve rotation))
            {
                GameObject valve = Instantiate(rotation.GetActualPrefab(), child);

                valve.GetComponent<SpriteRenderer>().size = new Vector2(divDimension, divDimension);

                BoxCollider2D[] childColliders = valve.GetComponentsInChildren<BoxCollider2D>();
                foreach (BoxCollider2D col in childColliders)
                {
                    col.size *= divDimension;
                    col.offset *= divDimension;
                }

                valve.transform.localPosition = Vector3.zero;
            }
        }
    }

    private void SetupStarts()
    {
        gameManager.turns = startPos.Length;

        for (int y = 0; y < ld.matrixY; y++)
        {
            for (int x = 0; x < ld.matrixX; x++)
            {
                if(ArrayContains(startPos, (x, y))) {
                    int index = GetIndex(startPos, (x, y));

                    GameObject bloodGO = Instantiate(prefabSquareBlood, GetTileTransform(x, y));
                    bloodGO.name = "Blood"+(index+1).ToString();
                    BloodMovement bloodMovement = bloodGO.GetComponent<BloodMovement>();
                    bloodMovement.jaugeBlood = actualJauge.GetComponent<JaugeBlood>();
                    //bloodMovement.valveNbr = valvePos.Count;
                    RectTransform bloodRect = bloodGO.GetComponent<RectTransform>();
                    bloodRect.sizeDelta = new Vector2(divDimension, divDimension);

                    BoxCollider2D[] childColliders = bloodGO.GetComponentsInChildren<BoxCollider2D>();
                    foreach (BoxCollider2D col in childColliders)
                    {
                        col.size = new Vector2(divDimension+15, divDimension+15);
                    }

                    if (ld.startSprites[index].Equals("small"))
                    {
                        switch (ld.startDirections[index])
                        {
                            case "top":
                                GameObject startGOTop = Instantiate(prefabSmallBloodTop, GetTileTransform(x, y));
                                RectTransform startRectTop = startGOTop.GetComponent<RectTransform>();
                                float heightTop = divDimension / 2.4f;
                                startRectTop.sizeDelta = new Vector2(divDimension, heightTop);
                                float offsetTop = divDimension / 2f + heightTop / 2f;

                                startRectTop.localPosition = new Vector3(0, offsetTop, 0);
                                bloodRect.localPosition = new Vector3(0, divDimension, 0);

                                startGOTop.GetComponentInChildren<TextMeshProUGUI>().text = (index + 1).ToString();
                                break;
                            case "bottom":
                                GameObject startGOBot = Instantiate(prefabSmallBloodBot, GetTileTransform(x, y));
                                RectTransform startRectBot = startGOBot.GetComponent<RectTransform>();
                                float heightBot = divDimension / 2.4f;
                                startRectBot.sizeDelta = new Vector2(divDimension, heightBot);
                                float offsetBot = divDimension / 2f + heightBot / 2f;

                                startRectBot.localPosition = new Vector3(0, -offsetBot, 0);
                                bloodRect.localPosition = new Vector3(0, -divDimension, 0);

                                startGOBot.GetComponentInChildren<TextMeshProUGUI>().text = (index + 1).ToString();
                                break;
                            default:
                                Debug.Log("Error : incorrect start direction");
                                break;
                        }
                        

                    } else
                    {
                        GameObject startGO = Instantiate(prefabBigBlood, GetTileTransform(x, y));
                        RectTransform startRect = startGO.GetComponent<RectTransform>();
                        startRect.sizeDelta = new Vector2(divDimension, divDimension);

                        startRect.localPosition = new Vector3(-divDimension, 0, 0);
                        bloodRect.localPosition = new Vector3(-divDimension, 0, 0);

                        startGO.GetComponentInChildren<TextMeshProUGUI>().text = (index + 1).ToString();
                    }
                }
            }
        }
    }

    private void SetupEnd()
    {
        for (int y = 0; y < ld.matrixY; y++)
        {
            for (int x = 0; x < ld.matrixX; x++)
            {
                if(endPos == (x, y))
                {
                    GameObject jaugeGO = Instantiate(prefabArrivee, GetTileTransform(x, y));
                    RectTransform jaugeRect = jaugeGO.GetComponent<RectTransform>();
                    float ratioWidth = divDimension* 0.25f;
                    float ratioHeigth = divDimension * 0.66f;
                    float offset = (divDimension / 2);

                    GameObject endGO = Instantiate(prefabEnd, GetTileTransform(x, y));
                    

                    endGO.name = "End";
                    RectTransform endRect = endGO.GetComponent<RectTransform>();
                    endRect.sizeDelta = new Vector2(divDimension, divDimension);
                    endGO.GetComponentInChildren<SpriteRenderer>().size *= divDimension;

                    jaugeRect.localPosition = new Vector3(offset, 0, 0);
                    endRect.localPosition = new Vector3(divDimension, 0, 0);

                    BoxCollider2D[] childColliders = endGO.GetComponentsInChildren<BoxCollider2D>();
                    foreach (BoxCollider2D child in childColliders)
                    {
                        child.size *= divDimension;
                        child.offset *= divDimension;
                    }

                    JaugeBlood jaugeBlood = actualJauge.GetComponent<JaugeBlood>();
                    switch (startPos.Length)
                    {
                        case 1:
                            jaugeBlood.stade1 = 100 ;
                            jaugeBlood.stade2 = 100;
                            jaugeBlood.stade3 = 100;
                            break;
                        case 2:
                            jaugeBlood.stade1 = 50;
                            jaugeBlood.stade2 = 100;
                            jaugeBlood.stade3 = 100;
                            break;
                        case 3:
                            jaugeBlood.stade1 = 30;
                            jaugeBlood.stade2 = 60;
                            jaugeBlood.stade3 = 100;
                            break;
                        default:
                            Debug.Log("Error : incorrect number of starts for the jauge");
                            break;
                    }

                    gridManager.end = endGO;
                }
            }
        }
    }

    private void TranslateValues()
    {
        valvePos = new List<(int, int, String)>();
        for (int i = 0; i < ld.valvePositions.Length; i++)
        {
            String pos = ld.valvePositions[i];
            String orientation = ld.valveOrientation[i];
            (int, int, String) translatedPos = (int.Parse(pos.Substring(0, 1)), int.Parse(pos.Substring(1, 1)), orientation.ToLower());
            valvePos.Add(translatedPos);
        }

        startPos = new (int, int)[ld.startPositions.Length];
        for (int i = 0; i < ld.startPositions.Length; i++)
        {
            String pos = ld.startPositions[i];
            (int, int) translatedPos = (int.Parse(pos.Substring(0, 1)), int.Parse(pos.Substring(1, 1)));
            startPos[i] = translatedPos;
        }

        endPos = (int.Parse(ld.endPosition.Substring(0, 1)), int.Parse(ld.endPosition.Substring(1, 1)));
    }

    private bool ArrayContains((int, int)[] array, (int, int) value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] == value) return true;
        }
        return false;
    }

    private int GetIndex((int, int)[] array, (int, int) value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value) return i;
        }
        return -1;
    }

    private Transform GetTileTransform(int x, int y)
    {
        int counter = 0;
        int goal = y * ld.matrixX + x;

        foreach (Transform child in grid.transform)
        {
            if (counter == goal)
            {
                return child;   
            }
            counter++;
        }
        return null;
    }

    


}
