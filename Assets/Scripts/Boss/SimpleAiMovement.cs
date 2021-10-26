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

    private float targetTimerCurrent = 1;
    private float targetTimerMax = 1;

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
        UpdateTargetTimer();
        TryUpdateTarget();
        UpdateDestination();    
    }
    private void UpdateDestination()
    {
        if (target == null) 
            return; // targetting a DC'd player before aggro is updated

        Vector3 add = new Vector3(.001f, 0);
        if (swapper)
        {
            swapper = !swapper;
            agent.SetDestination(target.position + add);
        }
        else
        {
            swapper = !swapper;
            agent.SetDestination(target.position - add);
        }
    }
    private void FindPlayer()
    {
        if (!isServer)
            return;

        target = gameObject.GetComponent<BossAggroHandler>().GetPlayerWithAggro();
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
}
