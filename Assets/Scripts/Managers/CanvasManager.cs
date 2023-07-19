using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.IO;

public class CanvasManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer sfxMixer;

    [Header("Button")]
    public Button startButton;
    public Button settingsButton;
    public Button quitButton;
    public Button returnToMenuButton;
    public Button returnToGameButton;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public GameObject winMenu;

    [Header("Text")]
    public Text ambientSliderText;
    public Text sfxSliderText;
    // public Text fuelSliderValueText;
    public Text livesValueText;

    [Header("Slider")]
    public Slider ambientVolSlider;
    public Slider sfxVolSlider;
    public Slider fuelLevelSlider;

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1;
    }

    void ShowSettingsMenu()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        // pauseMenu.SetActive(false);
        // gameOverMenu.SetActive(false);
        // winMenu.SetActive(false);
    }

    public void ShowMainMenu()
    {
        if (SceneManager.GetActiveScene().name == "Level" || SceneManager.GetActiveScene().name == "Pause")
        {
            SceneManager.LoadScene("Title");
        }
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        // gameOverMenu.SetActive(false);
        // winMenu.SetActive(false);
    }

    void OnAmbientSliderValueChanged(float value)
    {
        if (ambientSliderText)
        {
            ambientSliderText.text = value.ToString();
            audioMixer.SetFloat("AmbientVol", value - 80);
        }
    }

    void OnSfxSliderValueChanged(float value)
    {
        if (sfxSliderText)
        {
            sfxSliderText.text = value.ToString();
            audioMixer.SetFloat("SFXVol", value - 80);
        }
    }
    //void OnFuelSliderValueChanged(float value)
    //{
    //    if (fuelSliderValueText)
    //    {
    //        fuelSliderValueText.text = value.ToString();
    //        // set new fuel level
    //    }
    //}

    void UpdateLifeText(int value)
    {
        livesValueText.text = value.ToString();
    }

    //void UpdateFuelText(float value)
    //{
    //    if (GameManager.instance.fuel <=0)
    //    {
    //        GameOver();
    //    }
    //}

    public void PauseGame()
    {
        SceneManager.LoadScene("Pause");
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        SceneManager.LoadScene("Level");
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1;
    }
    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    void GameOver()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("Win");
        // mainMenu.SetActive(false);
        // settingsMenu.SetActive(false);
        // winMenu.SetActive(false);
        //gameOverMenu.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(StartGame);

        if (settingsButton)
            settingsButton.onClick.AddListener(ShowSettingsMenu);

        if (quitButton)
            quitButton.onClick.AddListener(QuitGame);

        if (returnToMenuButton)
            returnToMenuButton.onClick.AddListener(ShowMainMenu);

        if (returnToGameButton)
            returnToGameButton.onClick.AddListener(ResumeGame);

        if (ambientVolSlider)
        {
            ambientVolSlider.onValueChanged.AddListener(OnAmbientSliderValueChanged);
            float mixerValue;
            audioMixer.GetFloat("AmbientVol", out mixerValue);
            ambientVolSlider.value = mixerValue + 80;
        }

        if (sfxVolSlider)
        {
            sfxVolSlider.onValueChanged.AddListener(OnSfxSliderValueChanged);
            float mixerValue;
            audioMixer.GetFloat("SFXVol", out mixerValue);
            sfxVolSlider.value = mixerValue + 80;
        }

        //if (fuelLevelSlider)
        //{
        //    fuelLevelSlider.onValueChanged.AddListener(OnFuelSliderValueChanged);
        //}

        if (livesValueText)
            GameManager.instance.onLifeValueChanged.AddListener(UpdateLifeText);

        //if (fuelSliderValueText)
        //    GameManager.instance.onFuelValueChanged.AddListener(UpdateFuelText);

        GameManager.instance.lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
