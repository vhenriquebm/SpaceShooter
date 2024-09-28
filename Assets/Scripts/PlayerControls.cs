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

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
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

           // transform.position = new Vector3(touchPosition.x, touchPosition.y, 0);
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
}
