using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;

    public bool isRange;
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

                // Poruszanie si� - Melee (naciera na przeciwnika)
                if (isMelee)
                    {
                        enemyNavMeshAgent.SetDestination(playersTransform.position);
            }

                // Poruszanie si� - Range (ucieka od przeciwnika)
                if (isRange)
                    {
                    enemyNavMeshAgent.SetDestination(transform.position + playersTransform.position);
                    //Vector3 enemyRun = transform.position - playersTransform.position;
                    //Vector3 newPos = transform.position + enemyRun;
                    //enemyNavMeshAgent.SetDestination(newPos);
                }
            }
            // Domy�lnie przeciwnik stoi w miejscu
            // Poruszanie si� - Stacionarny
            else
            {
                enemyNavMeshAgent.SetDestination(transform.position);
            }

    }
}
