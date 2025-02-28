using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class ViewSlider : MonoBehaviour
{
    [SerializeField] private GameObject camToSlide;
    [SerializeField] private GameObject objectOnCam;
    [SerializeField] private float maxOffsetX;
    [SerializeField] private float movementSpeed;

    private Vector2 currentDirection;

    private void Start()
    {
        camToSlide.transform.position = new Vector3(objectOnCam.transform.position.x, objectOnCam.transform.position.y, -10);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    Vector2 myDeltaDirection = touch.deltaPosition;
                    myDeltaDirection.y = 0;
                    currentDirection = myDeltaDirection * movementSpeed;
                    Debug.Log("Swipe");
                    CheckBoundaries(currentDirection);
                    break;

                case TouchPhase.Stationary:
                    CheckBoundaries(currentDirection);
                    break;

                default:
                    currentDirection = Vector2.zero;
                    break;
            }
        }
    }

    private void CheckBoundaries(Vector3 currentDirection)
    {
        if (Mathf.Abs(camToSlide.transform.position.x + currentDirection.x) > maxOffsetX)
        {
            currentDirection.x = 0;
        }
        currentDirection.y = 0;

        camToSlide.transform.position += currentDirection;
    }

}