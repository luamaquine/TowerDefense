using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private Waypoints Wpoints;


    private int waypointIndex;

    public void Start(){
        Wpoints = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
        
    }

    public void Update(){
        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
        Vector3 direction = Wpoints.waypoints[waypointIndex].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        /*Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);   
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);*/ 
    

        if (Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.2f){
            if (waypointIndex < Wpoints.waypoints.Length - 1){
                waypointIndex++;
            }
            else{
                Destroy(gameObject);
            }
        }
    }
}
