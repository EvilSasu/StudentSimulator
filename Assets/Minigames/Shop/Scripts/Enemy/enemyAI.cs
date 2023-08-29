using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    public bool isMelee;

    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
            if(enemyAwareness.isAgro)
            {

                // Poruszanie siê - Melee (naciera na przeciwnika)
                if (isMelee)
                    {
                        enemyNavMeshAgent.SetDestination(playersTransform.position);
                }
            }

            else
            {
                enemyNavMeshAgent.SetDestination(transform.position);
            }

    }
}
