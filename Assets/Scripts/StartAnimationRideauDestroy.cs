using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimationRideauDestroy : MonoBehaviour
{
    public GameObject rideau;


    // Start is called before the first frame update
    void Start()
    {
        rideau.SetActive(true);
    }

    public void RideauOff()
    {
        rideau.SetActive(false);
    }

}
