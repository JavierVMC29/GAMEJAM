using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject flashlight;

    public void Interact()
    {
        flashlight.SetActive(true);
        Destroy(gameObject);
    }
}
