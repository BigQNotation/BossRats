using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulationDamageOut : BossAccumulationStrategy
{
    int STATES = 5;
    float DAMAGEINCREASE = 20;

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
            gameObject.GetComponent<BossModifications>().damageDealtModPercent -= DAMAGEINCREASE * GetCurrentState();
            IncreaseState();
            gameObject.GetComponent<BossModifications>().damageDealtModPercent += DAMAGEINCREASE * GetCurrentState();
            ResetTimeToNextAccumulation();
        }
            
    }
    public override void ResetStrategy()
    {
        gameObject.GetComponent<BossModifications>().damageDealtModPercent -= (GetCurrentState() * DAMAGEINCREASE);
    }
    protected override void TryDecumulate()
    {
        if (IsDecumulationIntervalReady())
        {     
            gameObject.GetComponent<BossModifications>().damageDealtModPercent -= DAMAGEINCREASE * GetCurrentState();
            DecreaseState();
            gameObject.GetComponent<BossModifications>().damageDealtModPercent += DAMAGEINCREASE * GetCurrentState();
            ResetTimeToNextDecumulation();
        }
    }

}
