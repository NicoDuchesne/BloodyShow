using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string debut;

    public void GameStart()
    {
        SceneManager.LoadScene(debut);
    }

    public void GameFinish()
    {
        Application.Quit();
    }
}
