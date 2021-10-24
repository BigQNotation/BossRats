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

    private float targetTimerCurrent = 3;
    private float targetTimerMax = 1;
    private int playerSwapperIndex = 0; // refactor out into aggro handler class

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        FindPlayer();

    }
    void Update()
    {
        if (!isServer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;
        UpdateTargetTimer();
        TryUpdateTarget();
        UpdateDestination();    
    }
    void UpdateDestination()
    {
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
    void FindPlayer()
    {
        if (!isServer)
            return;

        target = gameObject.GetComponent<BossAggroHandler>().GetPlayerWithAggro();
        /*
        GameObject[] gamers =  GameObject.FindGameObjectsWithTag("Player");
        target = gamers[playerSwapperIndex].GetComponent<Transform>();

        if (playerSwapperIndex == 0)
            playerSwapperIndex = 1;
        else
            playerSwapperIndex = 0;
        */

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
