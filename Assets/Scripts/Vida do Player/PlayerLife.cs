using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHealth -= 10f;
            Debug.Log("Player hit, current health: " + currentHealth);
            Destroy(collision.gameObject);

            if (currentHealth <= 0f)
            {
                Debug.Log("Player died");
            }
        }
    }
}