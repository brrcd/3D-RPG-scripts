using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform player; // players transform;
    EnemyCombat combat;
    Interactable interactable;
    Transform mainBuilding; // main building transform;

    public float spotDistance;
    public int damage;

    private NavMeshAgent enemyNavMesh;
    private bool wasAttacked = false;

    void Start()
    {
        enemyNavMesh = GetComponent<NavMeshAgent>();
        combat = GetComponent<EnemyCombat>();
        interactable = GetComponent<Interactable>();
        
        player = Player.instance.transform;
        mainBuilding = MainBuilding.instance.transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        float distanceToMainBuilding = Vector3.Distance(mainBuilding.position, transform.position);

        enemyNavMesh.SetDestination(mainBuilding.position);
        combat.targetHealth = mainBuilding.GetComponent<HealthManager>();

        if (distanceToMainBuilding <= enemyNavMesh.stoppingDistance)
        {
            combat.Attack(damage);
        }
        
        if (interactable.isFocus && interactable.hasInteracted == false)
        {
            wasAttacked = true;
        }

        if (distanceToPlayer <= spotDistance || wasAttacked)
        {
            enemyNavMesh.SetDestination(player.position);
            combat.targetHealth = player.GetComponent<HealthManager>();

            if (distanceToPlayer <= enemyNavMesh.stoppingDistance)
            {
                combat.Attack(damage);
            }

            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spotDistance);
    }
}
