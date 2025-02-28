using UnityEngine;
public class saiveData : MonoBehaviour
{
    public saive saive ;

    public void Awake()
    {
        Initilaize();
        LoadFormJson();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) { SaveToJson();}
    }
    public void SaveToJson(saive newSaive)
    {
        
        string saiveData = JsonUtility.ToJson(newSaive);
        string filePath = Application.persistentDataPath + "/saiveData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, saiveData);
        Debug.Log("Sauvgarde effectu�e");
    }
    public void LoadFormJson()
    {
        string filePath = Application.persistentDataPath + "/saiveData.json";
        string saiveData = System.IO.File.ReadAllText(filePath);
        saive = JsonUtility.FromJson<saive>(saiveData);
        Debug.Log("chargement effectu�e");
        Debug.Log(saive.niveau2);
        //Debug.Log(saive.niveau3);
        //Debug.Log(saive.niveau4);

    }

    public void Initilaize()
    {
        string filePath = Application.persistentDataPath + "/saiveData.json";
        if (!System.IO.File.Exists(filePath))
        {
            string saiveData = JsonUtility.ToJson(saive);
            System.IO.File.WriteAllText(filePath, saiveData);
        }
        
    }

    public saive ReturnSave()
    {
        string filePath = Application.persistentDataPath + "/saiveData.json";
        string saiveData = System.IO.File.ReadAllText(filePath);
        saive newsaive = JsonUtility.FromJson<saive>(saiveData);
        return newsaive;
    }


}

[System.Serializable]
public class saive
{

    public bool niveau2;
    public bool niveau3;
    public bool niveau4;
    public bool niveau5;
    public bool niveau6;
    public bool niveau7;
    public bool niveau8;
    public bool niveau9;
    public bool niveau10;
    public bool niveau11;
    public bool niveau12;
    public bool niveau13;
    public bool niveau14;
    public bool niveau15;
}
