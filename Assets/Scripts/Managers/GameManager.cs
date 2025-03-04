using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager gridManager;
    [SerializeField] GameObject blockScreen;
    [SerializeField] GameObject victoryScreen;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] GameObject grid;
    [SerializeField] private Canvas canvas;
    [SerializeField] public int turns;

    public bool destroyed = false;
    public bool won = false;
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

                Scene scene = SceneManager.GetActiveScene();

                if (scene.name == "Niveau_TUTO_2")
                {
                    //TutoManager.OnActiveTuto5 = true;
                }
            }
            else
            {
                blockScreen.transform.GetChild(0).gameObject.SetActive(false);
                defeatScreen.transform.GetChild(0).gameObject.SetActive(true);
                Debug.Log("le jeu est perdu");
            }
        }
    }

}
