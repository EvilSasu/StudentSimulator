using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField]
    int damage = 10;

    [SerializeField]
    int speed = 500;

    Rigidbody rb;

    //AudioSource shootAS;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 bulletAccuracy = new Vector3(Random.Range(0, 0.2f), Random.Range(0, 0.2f), Random.Range(0, 0.2f));
        Vector3 direction = (target.position - transform.position) + bulletAccuracy;
        rb.AddForce(direction * speed * Time.deltaTime);
        //shootAS = GetComponent<AudioSource>();
        //shootAS.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.transform.tag == "Player")
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.DamagePlayer(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
