using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStrategyHandler : NetworkBehaviour
{
    BossStrategyConfigGenerator.GeneratedStrategy strategySet;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isServer)
        {
            CreateStrategy();
            EnableActiveStrategies();
        }
  

    }
    private void CreateStrategy()
    {
        if (strategySet != null)
            return;

        GameObject.Find("Boss").GetComponent<BossStrategyConfigGenerator>().GenerateRandomStrategyList();
        strategySet = GameObject.Find("Boss").GetComponent<BossStrategyConfigGenerator>().GetRandomStrategyList();
    }
    private void EnableActiveStrategies()
    {
        if (strategySet == null)
            return;
        strategySet.accumulationStrategy.isActiveStrategy = true;
        strategySet.chargeStrategy.isActiveStrategy = true;
        strategySet.devastationStrategy.isActiveStrategy = true;
        strategySet.metricStrategy.isActiveStrategy = true;
    }


}
