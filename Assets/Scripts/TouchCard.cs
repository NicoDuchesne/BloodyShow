using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCard : MonoBehaviour
{
    private Camera cam;
    Vector2 point = new Vector3();

    public Collider2D m_Collider;
    public Vector2 m_Center;
    public Vector2 m_Size, m_Min, m_Max;

    public FlipCard flipCard;

    public bool setObject;

    public GameObject _Object;


    void Start()
    {
        cam = Camera.main;

        //Fetch the Collider from the GameObject
        m_Collider = GetComponent<Collider2D>();
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
    }

    void Update()
    {
        if (point.x < m_Collider.bounds.max.x && point.y < m_Collider.bounds.max.y && point.x > m_Collider.bounds.min.x && point.y > m_Collider.bounds.min.y) 
        {
            Debug.Log("Oui");
            flipCard.FlipCardTest();
        }

        if (!setObject)
        {
            _Object.transform.position = point;
        }

    }

    void OnGUI()
    {
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        if (Input.GetMouseButtonDown(0))
        {
            setObject = true;
        }
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
            
        
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }
}
