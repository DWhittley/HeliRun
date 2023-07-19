using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    private Coroutine cameraMovementCoroutine;

    [SerializeField] private Vector2 JoystickSize = new Vector2(250, 250);
    [SerializeField] private Transform AnchorPoint;
    [SerializeField] private float cameraMoveAmplify = 3.0f;
    public JoyStick joyStick;
    private Finger MovementFinger;
    public Vector2 MovementAmount;
    private Vector2 initialTouchPosition;
    private float lastTouchTime = 0.0f;
    private float thisTouchTime;
    public CanvasManager CM;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleLoseFinger;
        ETouch.Touch.onFingerMove += HandleFingerMove;

    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleLoseFinger;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }

    private void HandleFingerDown(Finger touchedFinger)
    {
        thisTouchTime = Time.time;

        if (MovementFinger == null && touchedFinger.screenPosition.x <= Screen.width)
        {
            MovementFinger = touchedFinger;
            initialTouchPosition = touchedFinger.screenPosition; // Store initial touch position
            MovementAmount = Vector2.zero;
            joyStick.gameObject.SetActive(true);
            joyStick.joyStickObj.sizeDelta = JoystickSize;
        }
    }

    //private void HandleDoubleTap()
    //{
    //    CM.PauseGame();
    //}

    private void HandleLoseFinger(Finger lostFinger)
    {
        if (lostFinger == MovementFinger)
        {
            MoveCamera(centerLerpPoint.transform.position);
            MovementFinger = null;
            joyStick.KnobObj.anchoredPosition = Vector2.zero;
            MovementAmount = Vector2.zero;
        }
    }

    private void HandleFingerMove(Finger movedFinger)
    {
        if (movedFinger == MovementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = JoystickSize.x / 2f;
            ETouch.Touch currentTouch = movedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, initialTouchPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - initialTouchPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - initialTouchPosition;
            }

            joyStick.KnobObj.anchoredPosition = knobPosition;
            MovementAmount = knobPosition / maxMovement;
            JoyDirection(MovementAmount);
        }
    }

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float cameraMoveSpeed = 3f;
    [SerializeField] private float cameraReturnSpeed = 3f;
    [SerializeField] private Vector3 cameraCenterPosition = Vector3.zero;
    // [SerializeField] private Vector3 cameraOffset = new Vector3(2000f, 800f, 0f);
    [SerializeField] private GameObject upRightLerpPoint;
    [SerializeField] private GameObject upLeftLerpPoint;
    [SerializeField] private GameObject downRightLerpPoint;
    [SerializeField] private GameObject downLeftLerpPoint;
    [SerializeField] private GameObject upPoint;
    [SerializeField] private GameObject leftLerpPoint;
    [SerializeField] private GameObject downLerpPoint;
    [SerializeField] private GameObject rightLerpPoint;
    [SerializeField] private GameObject centerLerpPoint;

    void JoyDirection(Vector2 dir)
    {
        float dirThreshold = 0.2f; // Adjust the threshold value for how far the finger has to move once touched, as needed

        if (dir.magnitude < dirThreshold)
        {
            MoveCamera(centerLerpPoint.transform.position);
            return;
        }

        Vector3 cameraTargetPosition = cameraTransform.position + cameraMoveAmplify * new Vector3(dir.x, dir.y, 0f);

        
        float dotUp = Vector3.Dot(dir, Vector2.up); // Establish a dot product point for x and y finger movement position
        float dotDown = Vector3.Dot(dir, -Vector2.up);
        float dotRight = Vector3.Dot(dir, Vector2.right);
        float dotLeft = Vector3.Dot(dir, -Vector2.right);

        if (dotUp > dirThreshold) // Determine the closest lerp point based on the dot products
        {
            if (dotRight > dirThreshold)
                MoveCamera(upRightLerpPoint.transform.position);
            else if (dotLeft > dirThreshold)
                MoveCamera(upLeftLerpPoint.transform.position);
            else
                MoveCamera(upPoint.transform.position);
        }
        else if (dotDown > dirThreshold)
        {
            if (dotRight > dirThreshold)
                MoveCamera(downRightLerpPoint.transform.position);
            else if (dotLeft > dirThreshold)
                MoveCamera(downLeftLerpPoint.transform.position);
            else
                MoveCamera(downLerpPoint.transform.position);
        }
        else if (dotRight > dirThreshold)
        {
            MoveCamera(rightLerpPoint.transform.position);
        }
        else if (dotLeft > dirThreshold)
        {
            MoveCamera(leftLerpPoint.transform.position);
        }
    }
    private void MoveCamera(Vector3 targetPosition)
    {
        if (cameraMovementCoroutine != null)
            StopCoroutine(cameraMovementCoroutine);

        cameraMovementCoroutine = StartCoroutine(MoveCameraCoroutine(targetPosition));
    }

    private IEnumerator MoveCameraCoroutine(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startPosition = cameraTransform.position;
        float smoothing = 0.3f; // lerp smoothing time factor

        while (elapsedTime < smoothing)
        {
            cameraTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / smoothing);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = targetPosition;
        cameraMovementCoroutine = null;
    }

    void Update()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<CanvasManager>();
    }
}
