using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class niveauAcesible : MonoBehaviour
{
    public saiveData saiveData;


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

    public void Start()  
    {
        //Debug.Log(myButtonNiveau2.interactable);
        //Debug.Log(myButtonNiveau3.interactable);
        //Debug.Log(myButtonNiveau4.interactable);
        //Debug.Log(myButtonNiveau5.interactable);
        Debug.Log(saiveData.saive.niveau2);
        //Debug.Log(saive.saive.niveau3);
        //Debug.Log(saive.saive.niveau4);
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
