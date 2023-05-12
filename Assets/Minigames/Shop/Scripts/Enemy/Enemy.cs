using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager enemyManager;
    public float enemyHealth = 2f;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDestroy()
    {
        enemyManager.enemiesInTrigger.Remove(this);

    }

    // Update is called once per frame
    void Update()
    {
        //sprawdzanie zdrowia
        if (enemyHealth <=0 )
        {
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
    }
}
