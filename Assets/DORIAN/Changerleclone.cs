using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changerleclone : MonoBehaviour
{
    public Image imageUI;

    // Sprite à changer
    public Sprite nouveauSprite;

    public void ChangerLeSprite()
    {
        // Vérifie si l'image UI est assignée
        if (imageUI != null && nouveauSprite != null)
        {
            // Change l'image affichée
            imageUI.sprite = nouveauSprite;
        }
        else
        {
            Debug.LogError("Image UI ou Nouveau Sprite non assigné !");
        }
    }
}
