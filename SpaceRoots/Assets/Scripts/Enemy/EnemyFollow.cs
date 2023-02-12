using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    [SerializeField]
    private Player player;
    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        sound.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        enemyAgent.destination = player.transform.position;
    }

    private void FixedUpdate()
    {
        if (enemyAgent.remainingDistance < 0)
        {
            Debug.Log(enemyAgent.remainingDistance);
            player.TakeDamage(1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(1);
        }
    }
}
