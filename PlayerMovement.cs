using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Transform target;
    PlayerCombat combat;
    PlayerStats playerStats;

    public Interactable focus;
    public int damage;

    private NavMeshAgent playerNavMesh;
    private Camera mainCamera;

    void Start()
    {
        playerNavMesh = GetComponent<NavMeshAgent>();
        mainCamera = Camera.main;
        combat = GetComponent<PlayerCombat>();
        playerStats = PlayerStats.instance;
    }

    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (target != null)
        {
            playerNavMesh.SetDestination(target.position);
            FaceTarget();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                MoveToPoint(hit.point);
            }

            RemoveFocus();
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null && interactable.tag == "Enemy")
                {
                    SetFocus(interactable);
                    combat.targetHealth = interactable.GetComponent<HealthManager>();
                    float distance = Vector3.Distance(transform.position, target.position);
                    if (playerStats.currentAttackRange >= distance)
                    {
                        combat.Attack(damage);
                        playerNavMesh.stoppingDistance = playerStats.currentAttackRange;
                    }
                }
                else if(interactable != null)
                {
                    SetFocus(interactable);
                }
                else
                {
                    Debug.Log("something went wrong");
                }
            }
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        playerNavMesh.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        playerNavMesh.stoppingDistance = newTarget.interactionRadius * .8f;
        playerNavMesh.updateRotation = false;

        target = newTarget.transform;
    }

    public void StopFollowTarget()
    {
        playerNavMesh.stoppingDistance = 0f;
        playerNavMesh.updateRotation = true;

        target = null;
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.OnDefocused();
            focus = newFocus;
            FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);

    }

    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        StopFollowTarget();
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
