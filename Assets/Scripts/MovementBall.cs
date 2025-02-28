using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class MovementBall : MonoBehaviour
{
    public float _speed = 1f;
    public bool _IsMovement = true;

    // Update is called once per frame
    void Update()
    {
        if (_IsMovement)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            _IsMovement = false;
        }
    }

    public void StartMovement()
    {
        _IsMovement = true;
    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Status Mouvement Bille: " + _IsMovement);
        GUILayout.Label("Speed Vitesse Bille Actuel: " + _speed);
        GUILayout.EndArea();

    }

}
