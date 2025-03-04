using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pipeCounterDisplay;
    private static PipeCounter instance = null;
    public static PipeCounter Instance => instance;
    private int counter = 0;

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

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Niveau1")
        {
            if (counter > 0)
            {
                Debug.Log("TUTO 1 OFF et 2 OFF");
                TutoManager.OnActiveTuto1 = false;
                TutoManager.OnActiveTuto2 = false;
            } 
        }

        if (scene.name == "Niveau_TUTO_1")
        {
            if (counter > 0)
            {
                Debug.Log("TUTO 3 OFF");
                TutoManager.OnActiveTuto3 = false;
            }
        }
        //if(counter > 0)
        //{
        //    etape1.OnActive1 = false;
        //}
    }

    private void UpdateDisplay()
    {
        if (counter <= 0)
        {
            pipeCounterDisplay.text = "";
        } else
        {
            pipeCounterDisplay.text = $"{counter}";
        }
    }

    public void Increment()
    {
        counter++;
        UpdateDisplay();
    }

    public void Decrement()
    {
        if (counter > 0)
        {
            counter--;
        }
        UpdateDisplay();
    }
}
