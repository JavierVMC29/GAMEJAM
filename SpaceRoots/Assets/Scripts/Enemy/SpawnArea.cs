using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public EnemyFollow enemyFollow;
    private AudioSource[] rootSounds;

    private void Start()
    {
        rootSounds = GetComponents<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(AudioSource rootSound in rootSounds)
            {
                rootSound.loop = true;
                rootSound.Play();
            }
            Invoke(nameof(StartFollow), 3f);
        }
    }

    void StartFollow()
    {
        enemyFollow.enabled = true;
    }
}
