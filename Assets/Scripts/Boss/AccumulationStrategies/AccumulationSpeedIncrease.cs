using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AccumulationSpeedIncrease : BossAccumulationStrategy
{
    readonly int STATES = 5;
    readonly float SPEEDINCREASE = 1;

    void Start()
    {
        SetNumberOfStates(STATES);
    }

    void Update()
    {
        if (!isActiveStrategy)
            return;
        UpdateTimeToNextAccumulation();
        UpdateTimeToNextDecumulation();
        TryDecumulate();
    }

    public override void UseStrategy()
    {
        if (IsAccumulationIntervalReady())
        {
            GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed -= SPEEDINCREASE * GetCurrentState();
            IncreaseState();
            GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed += SPEEDINCREASE * GetCurrentState();
            ResetTimeToNextAccumulation();
        }

    }
    public override void ResetStrategy()
    {
        GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed -= SPEEDINCREASE * GetCurrentState();
    }
    protected override void TryDecumulate()
    {
        if (IsDecumulationIntervalReady())
        {
            GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed -= SPEEDINCREASE * GetCurrentState();
            DecreaseState();
            GameObject.Find("Boss").GetComponent<NavMeshAgent>().speed += SPEEDINCREASE * GetCurrentState();
            ResetTimeToNextDecumulation();
        }
    }
}
