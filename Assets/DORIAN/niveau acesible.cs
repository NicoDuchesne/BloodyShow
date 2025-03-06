using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class niveauAcesible : MonoBehaviour
{
    public saiveData saiveData;

    [SerializeField] Button myButtonNiveau1;
    [SerializeField] Button myButtonNiveau2;
    [SerializeField] Button myButtonNiveau3;
    [SerializeField] Button myButtonNiveau4;
    [SerializeField] Button myButtonNiveau5;
    [SerializeField] Button myButtonNiveau6;
    [SerializeField] Button myButtonNiveau7;
    [SerializeField] Button myButtonNiveau8;
    [SerializeField] Button myButtonNiveau9;
    [SerializeField] Button myButtonNiveau10;
    [SerializeField] Button myButtonNiveau11;
    [SerializeField] Button myButtonNiveau12;
    [SerializeField] Button myButtonNiveau13;
    [SerializeField] Button myButtonNiveau14;
    [SerializeField] Button myButtonNiveau15;
    [SerializeField] Sprite shinyStar;
    private Color myYellow = new Color(255 / 255f, 241 / 255f, 106 / 255f, 255 / 255f);

    public void Start()  
    {
        myButtonNiveau2.interactable = saiveData.saive.niveau2;
        myButtonNiveau3.interactable = saiveData.saive.niveau3;
        myButtonNiveau4.interactable = saiveData.saive.niveau4;
        myButtonNiveau5.interactable = saiveData.saive.niveau5;
        myButtonNiveau6.interactable = saiveData.saive.niveau6;
        myButtonNiveau7.interactable = saiveData.saive.niveau7;
        myButtonNiveau8.interactable = saiveData.saive.niveau8;
        myButtonNiveau9.interactable = saiveData.saive.niveau9;
        myButtonNiveau10.interactable = saiveData.saive.niveau10;
        myButtonNiveau11.interactable = saiveData.saive.niveau11;
        myButtonNiveau12.interactable = saiveData.saive.niveau12;
        myButtonNiveau13.interactable = saiveData.saive.niveau13;
        myButtonNiveau14.interactable = saiveData.saive.niveau14;
        myButtonNiveau15.interactable = saiveData.saive.niveau15;

        myButtonNiveau1.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        UpdateStars(myButtonNiveau1.transform.GetChild(1), saiveData.saive.niveau1Star);
        if (saiveData.saive.niveau2)
        {
            myButtonNiveau2.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau2.transform.GetChild(1), saiveData.saive.niveau2Star);
        if (saiveData.saive.niveau3)
        {
            myButtonNiveau3.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau3.transform.GetChild(1), saiveData.saive.niveau3Star);
        if (saiveData.saive.niveau4)
        {
            myButtonNiveau4.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau4.transform.GetChild(1), saiveData.saive.niveau4Star);
        if (saiveData.saive.niveau5)
        {
            myButtonNiveau5.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau5.transform.GetChild(1), saiveData.saive.niveau5Star);
        if (saiveData.saive.niveau6)
        {
            myButtonNiveau6.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau6.transform.GetChild(1), saiveData.saive.niveau6Star);
        if (saiveData.saive.niveau7)
        {
            myButtonNiveau7.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau7.transform.GetChild(1), saiveData.saive.niveau7Star);
        if (saiveData.saive.niveau8)
        {
            myButtonNiveau8.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau8.transform.GetChild(1), saiveData.saive.niveau8Star);
        if (saiveData.saive.niveau9)
        {
            myButtonNiveau9.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau9.transform.GetChild(1), saiveData.saive.niveau9Star);
        if (saiveData.saive.niveau10)
        {
            myButtonNiveau10.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau10.transform.GetChild(1), saiveData.saive.niveau10Star);
        if (saiveData.saive.niveau11)
        {
            myButtonNiveau11.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau11.transform.GetChild(1), saiveData.saive.niveau11Star);
        if (saiveData.saive.niveau12)
        {
            myButtonNiveau12.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau12.transform.GetChild(1), saiveData.saive.niveau12Star);
        if (saiveData.saive.niveau13)
        {
            myButtonNiveau13.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau13.transform.GetChild(1), saiveData.saive.niveau13Star);
        if (saiveData.saive.niveau14)
        {
            myButtonNiveau14.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau14.transform.GetChild(1), saiveData.saive.niveau14Star);
        if (saiveData.saive.niveau15)
        {
            myButtonNiveau15.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = myYellow;
        }
        UpdateStars(myButtonNiveau15.transform.GetChild(1), saiveData.saive.niveau15Star);


    }

    private void UpdateStars(Transform stars, int counter)
    {
        if (counter == 0) {
            stars.gameObject.SetActive(false);
        } else
        {
            if (counter >= 1)
            {
                stars.GetChild(0).gameObject.GetComponent<Image>().sprite = shinyStar;
            }
            if (counter >= 2)
            {
                stars.GetChild(2).gameObject.GetComponent<Image>().sprite = shinyStar;
            }
            if (counter >= 3)
            {
                stars.GetChild(1).gameObject.GetComponent<Image>().sprite = shinyStar;
            }
        }
    }
    //public void Update()
    //{
    //    Debug.Log(saiveData.saive.niveau2);
    //    myButtonNiveau2.interactable = saiveData.saive.niveau2;
    //    myButtonNiveau3.interactable = saiveData.saive.niveau3;
    //    myButtonNiveau4.interactable = saiveData.saive.niveau4;
    //    myButtonNiveau5.interactable = saiveData.saive.niveau5;
    //    myButtonNiveau6.interactable = saiveData.saive.niveau6;
    //    myButtonNiveau7.interactable = saiveData.saive.niveau7;
    //    myButtonNiveau8.interactable = saiveData.saive.niveau8;
    //    myButtonNiveau9.interactable = saiveData.saive.niveau9;
    //    myButtonNiveau10.interactable = saiveData.saive.niveau10;
    //    myButtonNiveau11.interactable = saiveData.saive.niveau11;
    //    myButtonNiveau12.interactable = saiveData.saive.niveau12;
    //    myButtonNiveau13.interactable = saiveData.saive.niveau13;
    //    myButtonNiveau14.interactable = saiveData.saive.niveau14;
    //    myButtonNiveau15.interactable = saiveData.saive.niveau15;
    //}


}
