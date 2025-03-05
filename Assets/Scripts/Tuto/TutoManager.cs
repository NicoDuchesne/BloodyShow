using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    public GameObject dialogue1;
    public static bool OnActiveTuto1 = true;
    public static bool OnActiveTuto2 = false;

    public Animator anim;
    public Animator animHand;

    //TUTO 2
    public GameObject dialogue2;
    public static bool OnActiveTuto3 = true;
    public GameObject anim2;

    //TUTO 3
    public GameObject dialogue3;
    public static bool OnActiveTuto4 = true;
    public GameObject anim3;

    //TUTO 4
    public GameObject dialogue4;
    public static bool OnActiveTuto5 = true;


    void Update()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Niveau1")
        {
            if (OnActiveTuto1)
            {
                OnAnimTuto1();
            }
            else
            {
                OFFAnimTuto1();

            }

            if (OnActiveTuto2)
            {
                OnAnimTuto2();
            }
            else
            {
                OFFAnimTuto2();
            }
        }

        if (scene.name == "Niveau2")
        {
            if (OnActiveTuto3)
            {
                OnAnimTuto3();
            }
            else
            {
                OFFAnimTuto3();

            }
        }
        
        if (scene.name == "Niveau3")
        {
            if (OnActiveTuto4)
            {
                OnAnimTuto4();
            }
            else
            {
                OFFAnimTuto4();

            }
        }

        if (scene.name == "Niveau4")
        {
            if (OnActiveTuto5)
            {
                OnAnimTuto5();
            }
            else
            {
                OFFAnimTuto5();

            }
        }
    }
    

    //TUTO 1
    void OnAnimTuto1()
    {
        anim.SetBool("IsValide", true);
    }

    void OFFAnimTuto1()
    {
        anim.SetBool("IsValide", false);
    }

    void OnAnimTuto2()
    {
        animHand.SetBool("IsTuto2", true);
    }

    void OFFAnimTuto2()
    {
        animHand.SetBool("IsTuto2", false);
    }

    //tuto 2
    void OnAnimTuto3()
    {
        
    }

    void OFFAnimTuto3()
    {
        anim2.SetActive(false);
    }

    //tuto 3
    void OnAnimTuto4()
    {
        anim3.SetActive(true);
    }

    void OFFAnimTuto4()
    {
        anim3.SetActive(false);
    }

    //tuto 4
    void OnAnimTuto5()
    {
        //dialogue4.SetActive(true);
    }

    void OFFAnimTuto5()
    {
        //dialogue4.SetActive(false);
    }
}
