using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class SimpleAiMovement : NetworkBehaviour
{
    NavMeshAgent agent;
    //[SerializeField] Transform target;
    Transform target;
    bool swapper = true;
    [SerializeField] GameObject playerLoadHandler;

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

        GameObject[] gamers =  GameObject.FindGameObjectsWithTag("Player");
        target = gamers[0].GetComponent<Transform>();

    }
}
