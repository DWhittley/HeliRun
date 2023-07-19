using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public RectTransform joyStickObj;
    public RectTransform KnobObj;

    private void Awake()
    {
        //joyStickObj = GetComponent<RectTransform>();
        //KnobObj = GetComponentInChildren<RectTransform>();
    }
}
