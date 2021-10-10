using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulationDamageOut : BossAccumulationStrategy
{
    int STATES = 5;
    int DAMAGEINCREASE = 20;

    // Start is called before the first frame update
    void Start()
    {
        SetNumberOfStates(STATES);
    }

    // Update is called once per frame
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
            gameObject.GetComponent<BossModifications>().damageIncreasePercent -= DAMAGEINCREASE * GetCurrentState();
            IncreaseState();
            gameObject.GetComponent<BossModifications>().damageIncreasePercent += DAMAGEINCREASE * GetCurrentState();
            ResetTimeToNextAccumulation();
        }
            
    }
    public override void ResetStrategy()
    {
        gameObject.GetComponent<BossModifications>().damageIncreasePercent -= (GetCurrentState() * DAMAGEINCREASE);
    }
    protected override void TryDecumulate()
    {
        if (IsDecumulationIntervalReady())
        {     
            gameObject.GetComponent<BossModifications>().damageIncreasePercent -= DAMAGEINCREASE * GetCurrentState();
            DecreaseState();
            gameObject.GetComponent<BossModifications>().damageIncreasePercent += DAMAGEINCREASE * GetCurrentState();
            ResetTimeToNextDecumulation();
        }
    }

}
