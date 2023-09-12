using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAtack : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;

    [SerializeField]
    GameObject projectile;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float turnSpeed = 30;

    Transform target;

    //[SerializeField]
    float fireRate = 0.2f;


    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

            if (enemyAwareness.isAgro)
            {
                fireRate -= Time.deltaTime;

                Vector3 direction = target.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

                if (fireRate <= 0)
                {
                    //tutaj zmieniaæ fire Rate
                    fireRate = 0.5f;
                    Shoot();
                }
            }

        {
        }


    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }

}
