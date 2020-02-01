using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
   
   
    public int damage = 50;

    void Start()
    {
        target = waypoints.points[0];
    }

   

    public void seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    
    void Damage(Transform ennemy)
    {
       Ennemy e = ennemy.GetComponent<Ennemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }

        
    }

    void HitTarget()
    {
        //Debug.Log("TOUCHE !!!");

        Destroy(target.gameObject);

        Destroy(gameObject);
    }
}
