using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlayerControls : MonoBehaviour
{
    private Camera camera;
    private Vector3 offset;

    private float maxLeft;
    private float maxRight;
    private float maxDown;
    private float maxUp;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        StartCoroutine(SetBoundaries());

    }

    // Update is called once per frame
    void Update()
    {
        if (Touch.fingers[0].isActive)
        {
            Touch myTouch = Touch.activeTouches[0];
            Vector3 touchPosition = myTouch.screenPosition;
            touchPosition = camera.ScreenToWorldPoint(touchPosition);

            if (Touch.activeTouches[0].phase == TouchPhase.Began)
            {
                offset = touchPosition - transform.position;
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPosition.x-offset.x, touchPosition.y-offset.y, 0);
            }

            if (Touch.activeTouches[0].phase == TouchPhase.Stationary)
            {
                transform.position = new Vector3(touchPosition.x - offset.x, touchPosition.y - offset.y, 0);

            }

           // transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeft, maxRight), Mathf.Clamp(transform.position.y, maxDown, maxUp), 0);
        }
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private IEnumerator SetBoundaries()
    {
        yield return new WaitForEndOfFrame();

        maxLeft = camera.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = camera.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;

        maxDown = camera.ViewportToWorldPoint(new Vector2(0, 0.05f)).y;
        maxUp = camera.ViewportToWorldPoint(new Vector2(0, 0.6f)).y;
    }
}
