using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changerleclone : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Sprite � changer
    public Sprite nouveauSprite;

   public void ChangerLeSprite()
    {
        // R�cup�re le SpriteRenderer attach� � l'objet
        spriteRenderer = GetComponent<SpriteRenderer>();

        // V�rifie que le SpriteRenderer est bien trouv�
        if (spriteRenderer != null && nouveauSprite != null)
        {
            // Change le sprite
            spriteRenderer.sprite = nouveauSprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer ou NouveauSprite non assign� !");
        }
    }
}
