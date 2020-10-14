using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public float power;
    public float range;
    public float time_between_shoot = 1f;
    private float cache_time_between_shoot = 0f;


    public Transform target;
    public Transform head;
    public Transform firepoint;

    

    public GameObject bullet_prefab;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    void UpdateTarget()
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy_tag");
        float short_dis = Mathf.Infinity;
        GameObject nearest = null;
        foreach(GameObject i in enemy)
        {
            float dis = Vector3.Distance(transform.position, i.transform.position);
            if(dis < short_dis)
            {
                short_dis = dis;
                nearest = i;
            }
        }

        if(nearest!=null && short_dis<=range)
        {
            target = nearest.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotaion = Quaternion.Lerp(head.rotation, lookrotation, 10*Time.deltaTime).eulerAngles;
        head.rotation = Quaternion.Euler(0f, rotaion.y, 0f);

        if(cache_time_between_shoot<=0)
        {
            shoot();
            cache_time_between_shoot = 1f / time_between_shoot;
        }
        else
        {
            cache_time_between_shoot -= Time.deltaTime;
        }
        
    }

    void shoot()
    {
        GameObject GO = Instantiate(bullet_prefab, firepoint.position, firepoint.rotation);
        bullet bullet = GO.GetComponent<bullet>();

        if(bullet !=null)
        {
            bullet.seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
