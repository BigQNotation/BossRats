using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulationDamageOut : BossAccumulationStrategy
{
    int STATES = 3;
    int DAMAGEINCREASE = 20;

    // Start is called before the first frame update
    void Start()
    {
        SetNumberOfStates(STATES);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UseStrategy()
    {
        gameObject.GetComponent<BossModifications>().damageIncreasePercent += DAMAGEINCREASE;
    }
    public override void ResetStrategy()
    {
        gameObject.GetComponent<BossModifications>().damageIncreasePercent -= (GetCurrentState() * DAMAGEINCREASE);
    }

}
