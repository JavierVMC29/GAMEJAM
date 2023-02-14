using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAdmin;
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorAdmin.SetTrigger("open");
            sound.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            doorAdmin.SetTrigger("close");
            sound.Play();
        }
    }

}
