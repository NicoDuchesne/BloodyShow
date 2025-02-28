using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDelete : MonoBehaviour
{
    public void RemoveTag(Collider2D pipes)
    {
        if (pipes.CompareTag("Player"))
        {
            Debug.Log("Player sur la case");
            gameObject.tag = "OFFpipe";
        }
    }

    void AddTag() {
            Debug.Log("ADD TAG");
            gameObject.tag = "Pipe";
    }
}
