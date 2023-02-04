using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float speed;
    private float damage;

    private Vector3 lastPos;

    public void SetBullet(Transform target, float speed, float damage)
    {
        this.target = target;
        this.speed = speed;
        this.damage = damage;
        Destroy(gameObject, 0.7f);
    }
    
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            lastPos = transform.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
