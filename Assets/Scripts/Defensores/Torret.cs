using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    
    private List<Transform> EnemyPosList;
    private bool EnemyDetected;

    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    
    private void Start()
    {
        EnemyPosList = new List<Transform>();
    }

    private void FixedUpdate()
    {
        if (EnemyDetected)
        {
            Shoot();
        }
        else
        {
            EnemyDetected = EnemyPosList.Count > 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyPosList.Add(col.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyPosList.Remove(col.transform);
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        var script = bullet.AddComponent<Bullet>();
        script.SetBullet(EnemyPosList[0], bulletSpeed, damage);
    }
}
