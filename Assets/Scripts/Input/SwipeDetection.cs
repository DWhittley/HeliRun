using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    //public float minDist = .3f;
    //public float maxTime = .8f;

    //[Range(0, 1)]
    //public float dirThreshold = .9f;

    //Vector2 startPos;
    //float startTime;
    //Vector2 endPos;
    //float endTime;

    //private void OnEnable()
    //{
    //    InputManager.OnStartTouch += SwipeStart;
    //    InputManager.OnEndTouch += SwipeEnd;
    //}

    //void SwipeStart(Vector2 pos, float time)
    //{
    //    startPos = pos;
    //    startTime = time;
    //}

    //void SwipeEnd(Vector2 pos, float time)
    //{
    //    endPos = pos;
    //    endTime = time;
    //    CheckSwipe();
    //}

    //void CheckSwipe()
    //{
    //    if (Vector3.Distance(startPos, endPos) >= minDist && (endTime - startTime) <= maxTime)
    //    {
    //        Vector2 dir = endPos - startPos;
    //        SwipeDirection(dir);
    //        return;
    //    }
    //    if (Vector3.Distance(startPos, endPos) >= minDist && (endTime - startTime) > maxTime)
    //    {
    //        Vector2 dir = endPos - startPos;
    //        MoveDirection(dir);
    //        return;
    //    }
        
    //    // need double tap sensing to pause game or separate button on screen
    //    //if swipe detection fails then swipe is centered so return player to center of flight path
    //}

    //void SwipeDirection(Vector2 dir)
    //{
    //    Vector2 dirNormalized = dir.normalized;

    //    #region SwipeDetection
    //    if (Vector2.Dot(Vector2.up, dirNormalized) >= dirThreshold)
    //    {
    //        Debug.Log("swipe up");
    //        return;
    //    }

    //    if (Vector2.Dot(Vector2.down, dirNormalized) >= dirThreshold)
    //    {
    //        Debug.Log("swipe down");
    //        return;
    //    }

    //    if (Vector2.Dot(Vector2.left, dirNormalized) >= dirThreshold)
    //    {
    //        Debug.Log("swipe left");
    //        return;
    //    }

    //    if (Vector2.Dot(Vector2.right, dirNormalized) >= dirThreshold)
    //    {
    //        Debug.Log("swipe right");
    //        return;
    //    }
    //    #endregion


    //}
    //void MoveDirection(Vector2 dir)
    //{
    //    Vector2 dirNormalized = dir.normalized;

    //    float quadrant = 360.0f / 8; // sets how many directions player can select with swipe
    //    float halfQuadrant = quadrant / 2; // offset direction detection to middle of quadrant
    //    float angle = Mathf.Atan2(dirNormalized.x, dirNormalized.y) * Mathf.Rad2Deg;
    //    float x = dirNormalized.x;
    //    float y = dirNormalized.y;

    //    #region moveAngleDetection
    //    if (angle >= 157.5 && angle < 202.5 && (dirNormalized.x + dirNormalized.y) >= dirThreshold)
    //    {
    //        Debug.Log("swipe right");
    //        return;
    //    }
    //    else if (angle >= 112.5 && angle < 157.5)
    //    {
    //        Debug.Log("swipe up/right");
    //        return;
    //    }
    //    else if (angle >= 67.5 && angle < 112.5)
    //    {
    //        Debug.Log("swipe up");
    //        return;
    //    }
    //    else if (angle >= 22.5 && angle < 67.5)
    //    {
    //        Debug.Log("swipe UpLeft");
    //        return;
    //    }
    //    else if (angle >= 337.5 || angle < 22.5)
    //    {
    //        Debug.Log("swipe Left");
    //        return;
    //    }
    //    else if (angle >= 292.5 && angle < 337.5)
    //    {
    //        Debug.Log("swipe DownLeft");
    //        return;
    //    }
    //    else if (angle >= 247.5 && angle < 292.5)
    //    {
    //        Debug.Log("swipe Down");
    //        return;
    //    }
    //    else if (angle >= 202.5 && angle < 247.5)
    //    {
    //        Debug.Log("swipe DownRight");
    //        return;
    //    }
    //    #endregion

    //}
}
