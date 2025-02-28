using UnityEngine;

public class PipesCollider : MonoBehaviour
{
    //void OnTriggerStay2D(Collider2D pipes)
    //{
    //        if (pipes.CompareTag("Pipe"))
    //        {
    //            Debug.Log("Changement");
    //            pipes.tag = "OFFpipe";
    //            pipes.transform.parent.tag = "OFFpipe";

    //        }
    //}

    void OnTriggerEnter2D(Collider2D pipes)
    {
        if (pipes.CompareTag("Pipe"))
        {
            Debug.Log("Changement");
            pipes.tag = "OFFpipe";
            pipes.transform.parent.tag = "OFFpipe";

        }
    }


    void OnTriggerExit2D(Collider2D pipes)
    {
        Debug.Log("OnTrigger");
        pipes.tag = "Pipe";
        //pipes.transform.parent.tag = "Pipe";
    }


}