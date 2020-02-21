using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //bullets stats
    private Transform target;
    public float speed = 70f;
    public int damage = 50;

    //bullets targets
    public void Seek(Transform _target)
    {
        target = _target;
    }

    //bullet speed, they target ennemies
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

    //bullets inflict damage and destroy themselves
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
