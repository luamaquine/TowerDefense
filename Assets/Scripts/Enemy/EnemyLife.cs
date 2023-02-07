using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public float health;
    public GameObject deathEffect;
    public bool isAlive;

    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            Die();
        }
        else
        {
            isAlive = true;
        }
    }

    void Die(){
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameController.coins = GameController.coins+10;
    }
}
