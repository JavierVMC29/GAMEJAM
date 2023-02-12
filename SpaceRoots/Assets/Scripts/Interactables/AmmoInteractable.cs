using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoInteractable : MonoBehaviour,IInteractable
{
    [SerializeField]
    private Gun raygun;
    [SerializeField]
    private GameObject raygunObject;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (raygun.currentAmmo < raygun.maxAmmo && raygunObject.activeSelf)
        {
            raygun.AddAmmo();
            sound.Play();
            Invoke(nameof(PickUp), 0.5f);
        }
    }

    private void PickUp()
    {
        Destroy(gameObject);
    }
}
