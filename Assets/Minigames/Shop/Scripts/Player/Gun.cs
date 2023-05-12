using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   // public Animator shootAnim;

    public float range = 20f;
    public float horizontalRange = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;

    public float cDamage = 2f;
    public float sDamage = 1f;

    public float fireRate = 1f;
    public float nextFire;

    public int maxAmmo;
    public int ammo;


    //private int ammoLvl = 10;


    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    public EnemyManager enemyManager;
    private BoxCollider gunTrigger;

    // Start is called before the first frame update
    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(horizontalRange, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.42f);


        //ammoLvl = ammo;
        //ammoLvl = PlayerPrefs.GetInt("ammo");
    }

    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //ammo = ammoLvl;
        //PlayerPrefs.SetInt("ammo", ammo);   
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && ammo > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        //Animacja wystrza³u
        //shootAnim.SetTrigger("Shoot");

        //gunShotRadius
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        //powiadomianie przeciwnika o wystrzale
        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAgro = true;
        }


        //zrañ przeciwnika
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            //kierunek do przeciwnika
            var dir = enemy.transform.position - transform.position;

            RaycastHit hit;
            if(Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if(hit.transform == enemy.transform)
                {
                    //obra¿enia w zale¿noœci od dystansu
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);

                    if(dist > range * 0.5f)
                    {
                        //przeciwnik zraniony ma³e obra¿enia
                        enemy.TakeDamage(sDamage);

                        //sprawdzenie w co trafia
                        //Debug.DrawRay(transform.position, dir, Color.green);
                        //Debug.Break();
                    }
                    else
                    {
                        //przeciwnik zraniony krytyczne obra¿enia
                        enemy.TakeDamage(cDamage);

                        //sprawdzenie w co trafia
                        //Debug.DrawRay(transform.position, dir, Color.green);
                        //Debug.Break();
                    }
                }
            }
            
        }

        //reset wystrza³u
        nextFire = Time.time + fireRate;

        //u¿ycie amunicji
        ammo--;
        UiManager.Instance.UpdateAmmo(ammo);
    }

    public void GetAmmo(int amount, GameObject pickup)
    {
        if(ammo < maxAmmo)
        {
            ammo += amount;
            Destroy(pickup);
        }

        if (ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        UiManager.Instance.UpdateAmmo(ammo);
    }

    private void OnTriggerEnter(Collider other)
    {
        //dodaj przeciwnika
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //usuñ przeciwnika
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
