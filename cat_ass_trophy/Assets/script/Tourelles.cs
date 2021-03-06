﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourelles : MonoBehaviour
{

    [SerializeField] private Transform target;

    [Header("Attributes")]

    public float range = 15f;



    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity Setup Fields")]

    public const string ennemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //bullets target ennemies automatically
    void UpdateTarget()
    {
        GameObject[] ennemis = GameObject.FindGameObjectsWithTag(ennemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in ennemis)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    //time between bullets
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountDown <= 0f)
        {
            if (target != null)
            {
                shoot();
                fireCountDown = 1f / fireRate;
            }
        }

        fireCountDown -= Time.deltaTime;
    }

    //instanciate bullet
    void shoot()
    {
        
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }

    /*void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        if (target)
            Gizmos.DrawLine(transform.position, target.position);

    }*/
}
