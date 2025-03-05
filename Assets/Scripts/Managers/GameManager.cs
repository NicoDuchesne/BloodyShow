using Codice.CM.Client.Differences.Graphic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GameObject blockScreen;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] GameObject grid;
    [SerializeField] private Canvas canvas;
    [SerializeField] public int turns;
    [SerializeField] private int twoStars;
    [SerializeField] private int threeStars;
    [SerializeField] private GameObject[] starsGO;
    [SerializeField] private Sprite starWin;


    [HideInInspector]public bool destroyed = false;
    [HideInInspector] public bool won = false;
    private int counter = 0;

    private static GameManager instance = null;
    public static GameManager Instance => instance;

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

    public void StartBlood()
    {
        gridManager.StartingPhase();

        won = false;
        blockScreen.transform.GetChild(0).gameObject.SetActive(true);

        if (counter < turns)
        {
            counter++;
            foreach (Transform child in grid.transform)
            {
                foreach (Transform grandChild in child)
                {
                    if (grandChild.gameObject.name.Equals("Blood" + counter.ToString()))
                    {
                        grandChild.gameObject.SetActive(true);
                    }
                }
                    
            }
            //canvas.transform.GetChild(counter).gameObject.SetActive(true);
        }
    }

    public void Update()
    {
        if(destroyed)
        {
            destroyed = false;
            if (won && counter < turns)
            {
                StartCoroutine(gridManager.NextPhase());
                
            } else if(won && counter == turns && gridManager.CheckWinCondition())
            {
                blockScreen.transform.GetChild(0).gameObject.SetActive(false);
                victoryScreen.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("le jeu est gagné");
                StartCoroutine(ManageStars());
                
            }
            else
            {
                blockScreen.transform.GetChild(0).gameObject.SetActive(false);
                defeatScreen.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("le jeu est perdu");
            }
        }
    }
    
    IEnumerator ManageStars()
    {
        int pipeCount = int.Parse(GameObject.Find("PipeCounter").GetComponent<TextMeshProUGUI>().text);

        yield return new WaitForSeconds(0.3f);
        starsGO[0].GetComponent<Image>().sprite = starWin;

        yield return new WaitForSeconds(0.3f);
        if (pipeCount <= twoStars)
        {
            starsGO[1].GetComponent<Image>().sprite = starWin;
        }

        yield return new WaitForSeconds(0.3f);
        if (pipeCount <= threeStars)
        {
            starsGO[2].GetComponent<Image>().sprite = starWin;
        }

        
    }

}
