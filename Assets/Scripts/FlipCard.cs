using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public SpriteRenderer cardRadiant;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipCardTest()
    {
        if(cardRadiant.flipX == true)
        {
           cardRadiant.flipX = false;
        }
        else
        {
           cardRadiant.flipX = true;
        }
    }
}
