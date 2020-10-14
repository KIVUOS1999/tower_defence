using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;
    public float bullet_speed = 10f;
    public GameObject particle_effect;

    public void seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Vector3 dir = target.position - transform.position;
            float distancethisframe = bullet_speed * Time.deltaTime;

            if(dir.magnitude <= distancethisframe)
            {
                HitTarget();
            }

            transform.Translate(dir.normalized * distancethisframe, Space.World);
        }
    }

    void HitTarget()
    {
        Destroy(gameObject);
        GameObject particle = Instantiate(particle_effect, transform.position, transform.rotation);
        Destroy(particle, 1.8f);
        Destroy(target.gameObject);
    }
}
