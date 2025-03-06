using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changerleclone : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Sprite à changer
    public Sprite nouveauSprite;

   public void ChangerLeSprite()
    {
        // Récupère le SpriteRenderer attaché à l'objet
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Vérifie que le SpriteRenderer est bien trouvé
        if (spriteRenderer != null && nouveauSprite != null)
        {
            // Change le sprite
            spriteRenderer.sprite = nouveauSprite;
        }
        else
        {
            Debug.LogError("SpriteRenderer ou NouveauSprite non assigné !");
        }
    }
}
