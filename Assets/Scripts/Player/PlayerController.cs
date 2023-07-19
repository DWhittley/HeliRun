using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioSourceManager asm;

    public float speed;
    public bool winner = false;

    //Audio Clips
    public AudioClip scoreSound;
    public AudioClip fuelSound;
    public AudioClip helicopterNoise;
    public AudioClip cloudHitSound;

    public Slider fuelSlider;
    public Text fuelSliderValueText;


    // Start is called before the first frame update
    void Start()
    {
        asm = GetComponent<AudioSourceManager>();
        if (!helicopterNoise)
            asm.PlayOneShot(helicopterNoise, true);
        fuelSlider.value = GameManager.instance.fuel;
    }

    // Update is called once per frame
    void Update()
    {
        fuelSlider.value = GameManager.instance.fuel;
        fuelSliderValueText.text = GameManager.instance.fuel.ToString("#");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Wall"))
        {
            if (cloudHitSound)
            {
                asm.PlayOneShot(cloudHitSound, false);
            }
            GameManager.instance.lives--;
        }

        if (collider.CompareTag("Points")) // not used.... yet
        {
            if (scoreSound)
            {
                asm.PlayOneShot(scoreSound, false);
            }
            GameManager.instance.score++; //add to score
        }

        if (collider.CompareTag("Fuel"))
        {
            if (fuelSound)
            {
                asm.PlayOneShot(fuelSound, false);
            }
            GameManager.instance.fuel += 50.0f; //add to fuel
        }

        if (collider.CompareTag("Checkpoint")) // not used.... yet
            GameManager.instance.currentLevel.UpdateCheckpoint(collider.gameObject.transform);
    }
}
