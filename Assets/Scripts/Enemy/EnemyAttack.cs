using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    private bool canHit;
    private EnemyLife target;

    [SerializeField] private float Cooldown;
    private float timePast;


    private void FixedUpdate()
    {
        if (canHit && timePast >= Cooldown)
        {
            target.TakeDamage(damage);
            timePast = 0;
        }
        else
        {
            timePast += Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canHit = true;
            target = col.gameObject.GetComponent<EnemyLife>();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            canHit = false;
            target = null;
        }
    }
}
