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

 //   public bool isRange;
 //  public bool isMelee;

    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {

        // Atakowanie - dystans
 //       if (isRange)
 //       {
            if (enemyAwareness.isAgro)
            {
                fireRate -= Time.deltaTime;

                Vector3 direction = target.position - transform.position;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

                if (fireRate <= 0)
                {
                    //tutaj zmieniaæ fire Rate
                    fireRate = 0.5f;
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    Shoot();
                }
            }

        {

        //Atakowanie - Wrêcz
        //if (isMelee)
        //{
        ////    Nie dzia³aj¹ce
        //        PlayerHealth playerHealth = GetComponent<PlayerHealth>();

        //    if (enemyAwareness.isAgro)
        //    {
        //        Vector3 direction = target.position - transform.position;
        //        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        //        StartCoroutine(AttackTime());


        //    }

        //    IEnumerator AttackTime()
        //    {
        //        yield return new WaitForSeconds(5f);
        //        PlayerHealth.Instance.DamagePlayer(meleeDamage);
        //        playerHealth.DamagePlayer(meleeDamage);
        //        yield return new WaitForSeconds(fireRate);
        //    }
        }


    }

    void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }

}
