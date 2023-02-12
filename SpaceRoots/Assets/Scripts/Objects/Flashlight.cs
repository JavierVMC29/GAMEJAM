using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private bool isOn = true;
    [SerializeField]
    private GameObject flashlight;
    private AudioSource sound;
    public int maxBatteries = 3;
    public int currentBatteries;
    public bool haveBatteries = true;
    [SerializeField]
    private float batteryDuration = 3f; // dos minutos
    private float currentBateryRemaining;

    [SerializeField]
    private HealthBar bateryLevel;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        currentBatteries = maxBatteries;
        currentBateryRemaining = batteryDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && isOn)
        {
            isOn = false;
            if (haveBatteries)
            {
                flashlight.SetActive(isOn);
            }
            sound.Play();
        }
        else if (Input.GetButtonDown("Fire2") && isOn == false)
        {
            isOn = true;
            if (haveBatteries)
            {
                flashlight.SetActive(isOn);
            }
            sound.Play();
        }
        if (isOn)
        {
            currentBateryRemaining -= Time.deltaTime;
            if(currentBateryRemaining <= 0f && haveBatteries)
            {
                UseBatteries();
            }
        }
    }

    void UseBatteries()
    {
        currentBatteries -= 1;
        bateryLevel.SetHealth(currentBatteries);
        if (currentBatteries <= 0)
        {
            OutOfBatteries();
        }
        else if (currentBatteries > 0)
        {
            currentBateryRemaining = batteryDuration;
        }
    }

    void OutOfBatteries()
    {
        haveBatteries = false;
        flashlight.SetActive(false);
    }

    public void AddBattery()
    {
        haveBatteries = true;
        currentBatteries += 1;
        bateryLevel.SetHealth(currentBatteries);
        currentBateryRemaining = batteryDuration;
    }
}
