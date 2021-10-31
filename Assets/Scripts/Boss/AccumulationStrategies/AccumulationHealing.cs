using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulationHealing : BossAccumulationStrategy
{
    private readonly int STATES = 5;
    private readonly float HEALINGINCREASE = 2;

    public override void UseStrategy()
    {
        if (IsAccumulationIntervalReady())
        {
            gameObject.GetComponent<BossModifications>().healthRegeneration -= HEALINGINCREASE * GetCurrentState();
            IncreaseState();
            gameObject.GetComponent<BossModifications>().healthRegeneration += HEALINGINCREASE * GetCurrentState();
            ResetTimeToNextAccumulation();
        }

    }
    public override void ResetStrategy()
    {
        gameObject.GetComponent<BossModifications>().healthRegeneration -= (GetCurrentState() * HEALINGINCREASE);
    }

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
    protected override void TryDecumulate()
    {
        if (IsDecumulationIntervalReady())
        {
            gameObject.GetComponent<BossModifications>().healthRegeneration -= HEALINGINCREASE * GetCurrentState();
            DecreaseState();
            gameObject.GetComponent<BossModifications>().healthRegeneration += HEALINGINCREASE * GetCurrentState();
            ResetTimeToNextDecumulation();
        }
    }

}
