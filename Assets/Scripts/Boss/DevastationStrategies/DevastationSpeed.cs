using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevastationSpeed : BossDevastationStrategy
{

    private float movementSpeedMod = 3;
    private bool devastationStartedAlready = false;

    void Start()
    {

        cooldownMax = 15;
        
        
    }
    void Update()
    {
        if (!isActiveStrategy)
            return;
        if (!devastationStartedAlready)
        {
            UseDevastation();
            devastationStartedAlready = true;
        }


        UpdateDevastationTimer();
        if (IsDevastationTimerEnd() && readyToReset)
            EndDevastation();
    }

    public override void UseDevastation()
    {
        StartDevastationTimer();
        readyToReset = true;
        IncreaseBossMovementSpeed();
    }
    protected override void EndDevastation()
    {
        DecreaseBossMovementSpeed();
        readyToReset = false;
    }

    private void IncreaseBossMovementSpeed()
    {
        GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed += movementSpeedMod;
    }
    private void DecreaseBossMovementSpeed()
    {
        GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed -= movementSpeedMod;
    }

}
