using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject flashlight;
    [SerializeField]
    private GameObject battteryLevel;

    public void Interact()
    {
        flashlight.SetActive(true);
        battteryLevel.SetActive(true);
        Destroy(gameObject);
    }
}
