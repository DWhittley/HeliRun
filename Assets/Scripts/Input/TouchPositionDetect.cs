using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPositionDetect : MonoBehaviour
{
    //public GameObject lastHit;
    //public Vector3 collision = Vector3.zero;
    //Plane plane;
    //Vector3 planeNormal;
    //Vector3 planePoint;

    void Start()
    {
        //planeNormal = -Camera.main.transform.forward; // defines the plane normal opposite to camera's forward direction
        //planePoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)); // set the position of the center of the camera viewport

        //plane = new Plane(planeNormal, planePoint); // store the appropriate plane vector

        //InputManager.OnStartTouch += HandleStartTouch; // subscribing to the start touch event
        //InputManager.OnEndTouch += HandleEndTouch; // subscribing to the end touch event
    }

    //    void HandleStartTouch(Vector2 touchPositon, float time)
    //    {
    //        var ray = Camera.main.ScreenPointToRay(touchPositon);

    //        float hitDist;
    //        if (plane.Raycast(ray, out hitDist))
    //        {
    //            Vector3 touchWorldPos = ray.GetPoint(hitDist); // store world position of touch

    //            Vector3 touchDirection = (touchWorldPos - plane.normal).normalized; // calculates normalized direction from the touch position to the center of the plane

    //            float angle = Vector3.Angle(planeNormal, touchDirection); // calculates angle between the touch direction and the plane's normal

    //            int quadrant = Mathf.FloorToInt(angle / 45.0f) + 1; // determine the quadrant based on the angle

    //            Debug.Log("Quadrant: " + quadrant);
    //            // need code to move the position of the camera/canvas to appropriate relative transform position
    //        }
    //    }

    //    void HandleEndTouch(Vector2 touchPosition, float time)
    //    {
    //        // recenter the camera/canvas to initial transform position
    //    }

    //    private void OnDestroy() // Unsubscribe from the touch events when the script is destroyed
    //    {
    //        InputManager.OnStartTouch -= HandleStartTouch;
    //        InputManager.OnEndTouch -= HandleEndTouch;
    //    }
}
