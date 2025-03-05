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
    [SerializeField] saiveData saiveData;


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
                CheckSceneAddAchievements();
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
        int stars = GetStars(pipeCount);
        UpdateSaves(stars);


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

    public int GetStars(int pipeCount)
    {
        if (pipeCount <= threeStars)
        {
            return 3;
        } else if (pipeCount <= twoStars)
        {
            return 2;
        } else
        {
            return 1;
        }
    }

    public void UpdateSaves(int stars)
    {
        string actualScene = SceneManager.GetActiveScene().name;

        saive mySave = saiveData.ReturnSave();

        switch (actualScene)
        {
            case "Niveau1":
                if(mySave.niveau1Star < stars) { mySave.niveau1Star = stars; }
                mySave.niveau2 = true;
                break;
            case "Niveau2":
                if (mySave.niveau2Star < stars) { mySave.niveau2Star = stars; }
                mySave.niveau3 = true;
                break;
            case "Niveau3":
                if (mySave.niveau3Star < stars) { mySave.niveau3Star = stars; }
                mySave.niveau4 = true;
                break;
            case "Niveau4":
                if (mySave.niveau4Star < stars) { mySave.niveau4Star = stars; }
                mySave.niveau5 = true;
                break;
            case "Niveau5":
                if (mySave.niveau5Star < stars) { mySave.niveau5Star = stars; }
                mySave.niveau6 = true;
                break;
            case "Niveau6":
                if (mySave.niveau6Star < stars) { mySave.niveau6Star = stars; }
                mySave.niveau7 = true;
                break;
            case "Niveau7":
                if (mySave.niveau7Star < stars) { mySave.niveau7Star = stars; }
                mySave.niveau8 = true;
                break;
            case "Niveau8":
                if (mySave.niveau8Star < stars) { mySave.niveau8Star = stars; }
                mySave.niveau9 = true;
                break;
            case "Niveau9":
                if (mySave.niveau9Star < stars) { mySave.niveau9Star = stars; }
                mySave.niveau10 = true;
                break;
            case "Niveau10":
                if (mySave.niveau10Star < stars) { mySave.niveau10Star = stars; }
                mySave.niveau11 = true;
                break;
            case "Niveau11":
                if (mySave.niveau11Star < stars) { mySave.niveau11Star = stars; }
                mySave.niveau12 = true;
                break;
            case "Niveau12":
                if (mySave.niveau12Star < stars) { mySave.niveau12Star = stars; }
                mySave.niveau13 = true;
                break;
            case "Niveau13":
                if (mySave.niveau13Star < stars) { mySave.niveau13Star = stars; }
                mySave.niveau14 = true;
                break;
            case "Niveau14":
                if (mySave.niveau14Star < stars) { mySave.niveau14Star = stars; }
                mySave.niveau15 = true;
                break;
            case "Niveau15":
                if (mySave.niveau15Star < stars) { mySave.niveau15Star = stars; }
                break;
            default :
                Debug.Log("Error while saving the stars");
                break;
        }

        saiveData.SaveToJson(mySave);

        CheckAllStars();
    }

    private void CheckAllStars()
    {
        saive mySave = saiveData.ReturnSave();

        int sum = mySave.niveau1Star + mySave.niveau2Star + mySave.niveau3Star + mySave.niveau4Star
            + mySave.niveau5Star + mySave.niveau6Star + mySave.niveau7Star + mySave.niveau8Star
            + mySave.niveau9Star + mySave.niveau10Star + mySave.niveau11Star + mySave.niveau12Star
            + mySave.niveau13Star + mySave.niveau14Star + mySave.niveau15Star;

        if (sum >= 45)
        {
            AchievementManager.UnlockTutorial7Achievement();
        }
    }

    void CheckSceneAddAchievements()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Niveau4")
        {
            AchievementManager.UnlockTutorial1Achievement();
        }
        if (scene.name == "Niveau5")
        {
            AchievementManager.UnlockTutorial2Achievement();
        }
        if (scene.name == "Niveau9")
        {
            AchievementManager.UnlockTutorial3Achievement();
        }
        if (scene.name == "Niveau10")
        {
            AchievementManager.UnlockTutorial4Achievement();
        }
        if (scene.name == "Niveau15")
        {
            AchievementManager.UnlockTutorial5Achievement();
            AchievementManager.UnlockTutorial6Achievement();
        }
    }

}
