using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinPlyrInfoLoad : MonoBehaviour
{
    private float lastAttemptTime;
    private float bestTimeYet;

    [Header("Component")]
    public TextMeshProUGUI lastTime;
    public TextMeshProUGUI bestTime;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();

        lastTime.text = lastAttemptTime.ToString("0.00");
        bestTime.text = bestTimeYet.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LoadData() // loadd the player prefs variables needed
    {
        lastAttemptTime = PlayerPrefs.GetFloat("LastAttemptTime", 0.0f);
        bestTimeYet = PlayerPrefs.GetFloat("BestTimeYet", 0.0f);
    }
}
