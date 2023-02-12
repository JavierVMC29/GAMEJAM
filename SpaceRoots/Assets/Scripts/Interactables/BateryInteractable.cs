using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BateryInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Flashlight flashlight;
    [SerializeField]
    private GameObject flashlightObject;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();   
    }

    public void Interact()
    {
        if(flashlight.currentBatteries < flashlight.maxBatteries && flashlightObject.activeSelf)
        {
            flashlight.AddBattery();
            sound.Play();
            Invoke(nameof(PickUp), 0.3f);
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
