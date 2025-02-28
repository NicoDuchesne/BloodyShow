using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject background;
    [SerializeField] private float slidingSpeed;
    [SerializeField] private float zoomingSpeed;
    [SerializeField] private float minZoomSize;
    [SerializeField] private float maxZoomSize;
    

    private Vector2 currentDirection;
    private float prevMagnitude = 0;
    private Bounds boundsWorld;
    private Bounds camBounds;

    private void Awake()
    {
        boundsWorld = background.GetComponent<SpriteRenderer>().bounds;
    }

    private void Start()
    {
        cam.transform.position = new Vector3(background.transform.position.x, background.transform.position.y, -10);

        UpdateBounds();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    currentDirection = -touch.deltaPosition * slidingSpeed;
                    CheckBoundaries(currentDirection);
                    break;

                case TouchPhase.Stationary:
                    currentDirection = Vector2.zero;
                    break;

                default:
                    currentDirection = Vector2.zero;
                    break;
            }
        }

        if (Input.touchCount == 2)
        {
            UnityEngine.Touch touch0 = Input.GetTouch(0);
            UnityEngine.Touch touch1 = Input.GetTouch(1);

            if (touch0.phase != TouchPhase.Moved || touch0.phase != TouchPhase.Moved)
            {
                prevMagnitude = 0;
            }

            if(touch0.phase == TouchPhase.Moved && touch1.phase == TouchPhase.Moved)
            {
                float magnitude = (touch1.position - touch0.position).magnitude;
                if (prevMagnitude == 0)
                {
                    prevMagnitude = magnitude;
                }
                float difference = magnitude - prevMagnitude;

                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + -difference * zoomingSpeed, minZoomSize, maxZoomSize);

                UpdateBounds();
                CheckBoundaries(Vector3.zero);
            }
        }
    }

    private void CheckBoundaries(Vector3 currentDirection)
    {
        Vector3 newPosition = cam.transform.position + currentDirection;

        cam.transform.position = new Vector3(
            Mathf.Clamp(newPosition.x, camBounds.min.x, camBounds.max.x),
            Mathf.Clamp(newPosition.y, camBounds.min.y, camBounds.max.y),
            cam.transform.position.z
            );
    }

    private void UpdateBounds()
    {
        float height = cam.orthographicSize;
        float width = height * cam.aspect;

        float minX = boundsWorld.min.x + width;
        float maxX = boundsWorld.extents.x - width;

        float minY = boundsWorld.min.y + height;
        float maxY = boundsWorld.extents.y - height;

        camBounds = new Bounds();
        camBounds.SetMinMax(
            new Vector3(minX, minY, 0f),
            new Vector3(maxX, maxY, 0f)
            );
    }

}