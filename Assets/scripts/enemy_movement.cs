using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed = 40;
    public float health = 30;
    public float damage = 80;

    private Transform target;
    private int waypoint = 0;

    private void Start()
    {
        target = waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if(Vector3.Distance(transform.position, target.position)<=0.2f)
            GetNextPoint();
    }

    void GetNextPoint()
    {
        if(waypoint >= waypoints.points.Length -1)
        {
            Destroy(gameObject);
            return;
        }

        waypoint++;
        target = waypoints.points[waypoint];
        
    }
}
