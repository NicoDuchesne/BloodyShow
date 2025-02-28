using UnityEngine;
using UnityEngine.SceneManagement;

public class TutoManager : MonoBehaviour
{
    public GameObject dialogue1;
    public static bool OnActiveTuto1 = true;
    public static bool OnActiveTuto2 = false;
    public static bool OnActiveTuto3 = true;
    public static bool OnActiveTuto4 = true;
    public static bool OnActiveTuto5 = false;

    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;



    public Animator anim;
    public Animator animHand;
    public Animator animPoche;
    public Animator animTuto4;

    //public string tutoSuivant;

    void Update()
    {

        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Niveau_TUTO_0")
        {
            if (OnActiveTuto1)
            {
                OnAnimTuto1();
            }
            else
            {
                OFFAnimTuto1();
                //SceneManager.LoadScene(tutoSuivant);
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

        if (scene.name == "Niveau_TUTO_1")
        {
            if (OnActiveTuto3)
            {
                OnAnimTuto3();
            }
            else
            {
                OFFAnimTuto3();
                OnActiveTuto4 = true;
            }

            if (OnActiveTuto4)
            {
                OnAnimTuto4();
            }
            else
            {
                OFFAnimTuto4();
                //SceneManager.LoadScene(tutoSuivant);

            }
        }

        if (scene.name == "Niveau_TUTO_2")
        {
            if (OnActiveTuto4)
            {
                OnAnimTuto4();
            }
            else
            {
                OFFAnimTuto4();
            }

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
        dialogue1.SetActive(false);
    }

    //TUTO 2

    void OnAnimTuto2()
    {
        animHand.SetBool("IsTuto2", true);
    }

    void OFFAnimTuto2()
    {
        animHand.SetBool("IsTuto2", false);
    }

    //TUTO 3  AUTRES SCENE

    void OnAnimTuto3()
    {
        animPoche.SetBool("IsOn", true);
    }

    void OFFAnimTuto3()
    {
        animPoche.SetBool("IsOn", false);
        dialogue3.SetActive(false);
    }

    //TUTO 4

    void OnAnimTuto4()
    {
        animTuto4.SetBool("IsOn", true);
        dialogue4.SetActive(true);
    }

    void OFFAnimTuto4()
    {
        animTuto4.SetBool("IsOn", false);
        dialogue4.SetActive(false);
    }

    //TUTO 5

    void OnAnimTuto5()
    {
        dialogue5.SetActive(true);
    }

    void OFFAnimTuto5()
    {
        dialogue5.SetActive(false);
    }
}
