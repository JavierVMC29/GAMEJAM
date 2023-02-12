using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    public Enemy enemy;
    private int num;

    private void Update()
    {
        if(num >= 2)
        {
            gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        num++;
        if (other.CompareTag("Enemy"))
        {
            enemy.TakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        num++;
        if (collision.collider.CompareTag("Enemy"))
        {
            enemy.TakeDamage(1);
        }
    }
}
