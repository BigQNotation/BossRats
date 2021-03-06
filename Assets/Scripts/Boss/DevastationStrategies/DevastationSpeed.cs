using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevastationSpeed : BossDevastationStrategy
{

    private float movementSpeedMod = 3;

    void Start()
    {

        cooldownMax = 15;
        
        
    }
    void Update()
    {
        if (!isActiveStrategy)
            return;

        UpdateDevastationTimer();
        if (IsDevastationTimerEnd() && devastationActive)
            EndDevastation();
    }

    public override void UseDevastation()
    {
        if (devastationActive) // only allow UseDevastion while it isn't already in progress
            return;
        StartDevastationTimer();
        devastationActive = true;
        IncreaseBossMovementSpeed();
    }
    protected override void EndDevastation()
    {
        DecreaseBossMovementSpeed();
        devastationActive = false;
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
