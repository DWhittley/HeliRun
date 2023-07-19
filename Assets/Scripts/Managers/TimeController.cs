using TMPro;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI lastTime;
    public TextMeshProUGUI bestTime;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    private float lastAttemptTime;
    private bool timerOn;
    private float bestTimeYet;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.SetTimeManager(this);
        
        LoadData(); // Load the saved data from the last run

        timerText.text = currentTime.ToString("0.00");
        lastTime.text = lastAttemptTime.ToString("0.00");
        bestTime.text = bestTimeYet.ToString("0.00");

        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
        }
        else
        {
            timerText.text = ("Paused");
        }
    }

    public void StartTimer()
    {
        timerOn = true;
    }

    public void StopTimer()
    {
        timerOn = false;
    }

    public void UpdateLastTime()
    {
        lastAttemptTime = currentTime;
        lastTime.text = currentTime.ToString("0.00");
        SaveData(); // Save the updated lastAttemptTime
    }

    public void UpdateBestTime()
    {
        if (lastAttemptTime > bestTimeYet)
        {
            bestTimeYet = lastAttemptTime;
            bestTime.text = bestTimeYet.ToString("0.00");
            SaveData(); // Save the updated bestTimeYet
        }
    }

    public void ResetTimer()
    {
        currentTime = 0f;
    }

    private void SaveData() // set the player prefs variables needed
    {
        PlayerPrefs.SetFloat("LastAttemptTime", lastAttemptTime);
        PlayerPrefs.SetFloat("BestTimeYet", bestTimeYet);
        PlayerPrefs.Save();
    }

    private void LoadData() // loadd the player prefs variables needed
    {
        lastAttemptTime = PlayerPrefs.GetFloat("LastAttemptTime", 0.0f);
        bestTimeYet = PlayerPrefs.GetFloat("BestTimeYet", 0.0f);
    }
}