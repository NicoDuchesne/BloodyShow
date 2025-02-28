using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveChengement : MonoBehaviour
{
    public Sprite Valve1;
    public Sprite Valve2;
    public SpriteRenderer spriteRenderer;
    public int valide = 0; 

    void Start()
    {
        // Récupère le SpriteRenderer du GameObject actuel
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Changemennt()
    {
        // Assurez-vous qu'il existe un SpriteRenderer sur cet objet
        if (spriteRenderer != null && Valve1 != null)
        {
            if (valide == 1)
            {
                // Change le sprite du SpriteRenderer
                spriteRenderer.sprite = Valve1;
            }
            else if (valide == 2)
            {
                spriteRenderer.sprite = Valve2;
            }

        }
       
    }

}
