using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JaugeBlood : MonoBehaviour
{
    public Slider slider;
    public bool blood1Here = false;
    public bool blood2Here = false;
    public bool blood3Here = false;
    //jauge
    //public int[] stades;
    public int stade1 = 30;
    public int stade2 = 60;
    public int stade3 = 100;
    public float fillSpeed = 20f;

    public void SetMaxBlood(int blood)
    {
        slider.maxValue = blood;
        slider.value = blood;
    }

    private void Start()
    {
        slider.maxValue = 100;
        slider.value = 0;
    }

    void Update()
    {
        if (blood1Here)
        {
            Setblood();
        }

        if (blood2Here)
        {
            Setblood();
        }

        if (blood3Here)
        {
            Setblood();
        }

    }

    void Setblood()
    {
        if (slider.value < stade1 && blood1Here == true)
        {
            slider.value += fillSpeed * Time.deltaTime;
            blood2Here = false;
            blood3Here = false;
        }

        if (slider.value < stade2 && blood2Here == true)
        {
            slider.value += fillSpeed * Time.deltaTime;
            blood1Here = false;
            blood3Here = false;
        }

        if (slider.value < stade3 && blood3Here == true)
        {
            slider.value += fillSpeed * Time.deltaTime;
            blood1Here = false;
            blood2Here = false;
        }
    }

    public void GameManageBloodJauge()
    {
        if (blood1Here == false && blood2Here == false && blood3Here == false)
        {
            blood1Here = true;
            blood2Here = false;
            blood3Here = false;
        }

        else if (blood1Here == true && blood2Here == false && blood3Here == false)
        {
            blood1Here = false;
            blood2Here = true;
            blood3Here = false;
        }

        else if (blood1Here == false && blood2Here == false && blood3Here == false)
        {
            blood1Here = false;
            blood2Here = false;
            blood3Here = true;
        }
    }
}
