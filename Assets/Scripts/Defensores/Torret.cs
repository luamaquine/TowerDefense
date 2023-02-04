using System.Collections.Generic;
using UnityEngine;

public class Torret : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    
    private List<Transform> EnemyPosList;
    private bool EnemyDetected;
    [SerializeField] private float ShootTime;
    private float currentTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;
    
    private void Start()
    {
        EnemyPosList = new List<Transform>();
    }

    private void FixedUpdate()
    {
        if (!EnemyDetected)
        {
            EnemyDetected = EnemyPosList.Count > 0;
        }
        else
        {
            if (currentTime >= ShootTime)
            {
                Shoot();
                currentTime = 0;
            }
            else
            {
                currentTime += Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyPosList.Add(col.transform);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            EnemyPosList.Remove(col.transform);
        }
    }

    private void Shoot()
    {
        if (EnemyPosList.Count > 0)
        {
            var bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            var script = bullet.AddComponent<Bullet>();
            script.SetBullet(EnemyPosList[0], bulletSpeed, damage);
        }
    }
}
