using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;


    public int damage = 50;


    public void Seek(Transform _target)
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
            Damage(target);
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

        Destroy(gameObject);
    }
}
