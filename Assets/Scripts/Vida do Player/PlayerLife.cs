using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerLife : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public Text lifeText;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        lifeText.text = currentHealth.ToString();
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
                SceneManager.LoadScene("GameOver");
                Debug.Log("Player died");
            }
        }
    }
}