using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    //tuto
    public GameObject dialogue1;
    public GameObject blockScreen;

    //tuto 2
    public GameObject dialogue2;

    //tuto 3
    public GameObject dialogue3;

    //tuto 4
    public GameObject dialogue4;




    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Scene scene = SceneManager.GetActiveScene();

            if (scene.name == "Niveau1")
            {
                dialogue1.SetActive(false);
                blockScreen.SetActive(false);
            }

            if (scene.name == "Niveau2")
            {
                dialogue2.SetActive(false);
                blockScreen.SetActive(false);
            }

            if (scene.name == "Niveau3")
            {
                dialogue3.SetActive(false);
                blockScreen.SetActive(false);
            }

            if (scene.name == "Niveau4")
            {
                dialogue4.SetActive(false);
                blockScreen.SetActive(false);
            }
        }
    }

    public void ProchainTexte()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
            //Pour tuto1
            TutoManager.OnActiveTuto2 = true;
            //pour tuto2
            TutoManager.OnActiveTuto3 = true;

        }
        //}
    }
}

