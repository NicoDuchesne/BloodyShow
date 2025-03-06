using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changerleclone : MonoBehaviour
{
    public Image imageUI;

    // Sprite � changer
    public Sprite nouveauSprite;

    public void ChangerLeSprite()
    {
        // V�rifie si l'image UI est assign�e
        if (imageUI != null && nouveauSprite != null)
        {
            // Change l'image affich�e
            imageUI.sprite = nouveauSprite;
        }
        else
        {
            Debug.LogError("Image UI ou Nouveau Sprite non assign� !");
        }
    }
}
