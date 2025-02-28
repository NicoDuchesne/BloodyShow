using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimationRideauDestroy : MonoBehaviour
{
    public GameObject rideau;


    public void RideauOn()
    {
        rideau.SetActive(true);
    }

    public void RideauOff()
    {
        rideau.SetActive(false);
    }

}
