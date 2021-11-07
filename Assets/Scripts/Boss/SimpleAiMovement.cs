using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class SimpleAiMovement : NetworkBehaviour
{
    NavMeshAgent agent;
    Transform target;
    bool swapper = true;
    [SerializeField] GameObject playerLoadHandler;

    private float targetTimerCurrent = 5f;
    private readonly float targetTimerMax = 5f;

    private readonly float distanceToBeginMovingTowardPlayer = 3f;
    private readonly float distanceToStopMovingTowardPlayer = 3f;
    private Vector3 stoppingDistance;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        FindPlayer();
    }
    private void Update()
    {
        if (!isServer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;
        if (target == null)
            return; // targetting a DC'd player before aggro is updated

        UpdateTargetTimer();
        TryUpdateTarget();
        UpdateStoppingDistance();
        if (IsPlayerFarEnoughAwayToAdvance())
            MoveToPlayer();
        else
            StrafeNearPlayer();
    }
    private void UpdateStoppingDistance()
    {
        if (target == null)
            return; // targetting a DC'd player before aggro is updated

        stoppingDistance = 
            Vector3.MoveTowards(gameObject.transform.position, 
                                target.position, 
                                Vector3.Distance(gameObject.transform.position, target.position) - distanceToStopMovingTowardPlayer);
    }
    private void StrafeNearPlayer()
    {

    }
    private bool IsPlayerFarEnoughAwayToAdvance()
    {
        

        if (Vector3.Distance(gameObject.transform.position, target.position) < distanceToBeginMovingTowardPlayer)
            return false;
        return true;
    }
    private void MoveToPlayer()
    {
        if (target == null) 
            return; // targetting a DC'd player before aggro is updated

        Vector3 add = new Vector3(.001f, 0);
        if (swapper)
        {
            swapper = !swapper;
            agent.SetDestination(stoppingDistance + add);
        }
        else
        {
            swapper = !swapper;
            agent.SetDestination(stoppingDistance - add);
        }
    }
    private void FindPlayer()
    {
        if (!isServer)
            return;

        target = gameObject.GetComponent<BossMovementAggroHandler>().GetPlayerWithAggro();
    }
    private void UpdateTargetTimer()
    {
        if (targetTimerCurrent > 0)
        {
            targetTimerCurrent -= Time.deltaTime;
        }
    }
    private void TryUpdateTarget()
    {
        if (targetTimerCurrent > 0)
            return;

        FindPlayer();
        targetTimerCurrent = targetTimerMax;
    }
    private Vector3 GetDistanceToPlayer()
    {
        return (gameObject.transform.position - target.position);
    }
}
