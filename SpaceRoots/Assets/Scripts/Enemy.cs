using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Hola 1");
        if (collision.collider.CompareTag("Player"))
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hola 2");
        if (collision.collider.tag == "Player")
        {
            TakeDamage(1);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.CompareTag("Player"))
        {
            TakeDamage(1);
        }
    }
}
