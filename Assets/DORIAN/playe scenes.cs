using UnityEngine;
using UnityEngine.SceneManagement;

public class playescenes : MonoBehaviour
{
    
    [SerializeField] saiveData saiveData;

    //Son
    public AudioSource audioSource;
    public AudioClip sound;

    public void LoadSceneMenue()
    {
        SceneManager.LoadScene("NextSceneName");
    }

    public void LoadNextScene()
    {
        string actualScene = SceneManager.GetActiveScene().name;

        switch (actualScene)
        {
            case "Niveau1":
                LoadSceneNiveau2();
                break;
            case "Niveau2":
                LoadSceneNiveau3();
                break;
            case "Niveau3":
                LoadSceneNiveau4();
                break;
            case "Niveau4":
                LoadSceneNiveau5();
                break;
            case "Niveau5":
                LoadSceneNiveau6();
                break;
            case "Niveau6":
                LoadSceneNiveau7();
                break;
            case "Niveau7":
                LoadSceneNiveau8();
                break;
            case "Niveau8":
                LoadSceneNiveau9();
                break;
            case "Niveau9":
                LoadSceneNiveau10();
                break;
            case "Niveau10":
                LoadSceneNiveau11();
                break;
            case "Niveau11":
                LoadSceneNiveau12();
                break;
            case "Niveau12":
                LoadSceneNiveau13();
                break;
            case "Niveau13":
                LoadSceneNiveau14();
                break;
            case "Niveau14":
                LoadSceneNiveau15();
                break;
            case "OriginalScene": 
                LoadSceneNiveau2();
                break;
        }
    }
    public void LoadSceneNiveau1()
    {
        SceneManager.LoadScene("Niveau1");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau2()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau2 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau2");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau3()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau3 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau3");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau4()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau4 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau4");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau5()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau5 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau5");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau6()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau6 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau6");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau7()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau7 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau7");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau8()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau8 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau8");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau9()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau9 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau9");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau10()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau10 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau10");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau11()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau11 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau11");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau12()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau2 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau12");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau13()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau2 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau13");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau14()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau2 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau14");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
    public void LoadSceneNiveau15()
    {
        //saive mySave = saiveData.ReturnSave();
        //mySave.niveau2 = true;
        //saiveData.SaveToJson(mySave);
        SceneManager.LoadScene("Niveau15");
        audioSource.PlayOneShot(sound);   //clic niveau
    }
}
