using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public int health = 100;
    public int value = 50;

    void Start()
    {
        target = waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, target.position) <= 0.2f)

            {
                GetNextWayPoint();
            }
        }
    }

    void GetNextWayPoint()
    {
        if (wavepointIndex >= waypoints.points.Length - 1)
        {
            Endpath();
            return;
        }
        wavepointIndex++;
        target = waypoints.points[wavepointIndex];
    }

    void Endpath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
