using System.Collections;
using TMPro;
using UnityEngine;


public class BloodMovement : MonoBehaviour
{
    
    //pour la jauge
    public JaugeBlood jaugeBlood;

    public Vector2 targetPosition;
    public float _speed = 10f;

    public bool isMoving = false;
    public bool isArrived = false;

    //public int valveNbr;
    //public int countValve = 0;

    public float maxInactivTime = 2f;
    private float InactivTimer;


    void OnTriggerStay2D(Collider2D pipes)
    {
        if (isMoving == false)
        {
             if (pipes.CompareTag("Pipe"))
             {
               Debug.Log("Entre");
                 if (pipes.transform.parent.gameObject.TryGetComponent<RotateValve>(out RotateValve rotate))
                 {
                   //countValve++;
                    rotate.counter++;
                    rotate.RefreshSprite();
                   //code pour  changer les sprites
                   //ValveChengement valveChengement = pipes.GetComponentInChildren<ValveChengement>();
                   //valveChengement.valide++;
                   //valveChengement.Changemennt();
                 }
                 if (pipes.transform.parent.gameObject.name.Equals("End"))
                 {
                   isArrived = true;
                   jaugeBlood.GameManageBloodJauge();
                 }
                 targetPosition = pipes.transform.position;
                 isMoving = true;
                 //pipes.enabled = false;
                 pipes.tag = "OFFpipe";
                 StartCoroutine(ChangeTag(pipes));
             }
        }
    }

    void Update()
    {
        if (isMoving)
        {
            InactivTimer = 0;
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
                Debug.Log("Sort");
            }
        }

        if (!isMoving)
        {
            InactivTimer += Time.deltaTime;

            if (InactivTimer > maxInactivTime)
            {

                if (/*countValve == valveNbr &&*/isArrived)
                {
                    GameManager.Instance.won = true;
                }
                GameManager.Instance.destroyed = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator ChangeTag(Collider2D pipes)
    {
        yield return new WaitForSeconds(_speed);
        pipes.tag = "Pipe";
    }
}



