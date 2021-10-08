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
            ServerEnableActiveStrategies();
        }
        if (isLocalPlayer)
        {
            ClientEnableActiveStrategies();
        }

    }
    private void CreateStrategy()
    {
        if (strategySet != null)
            return;

        GameObject.Find("Boss").GetComponent<BossStrategyConfigGenerator>().GenerateRandomStrategyList();
        strategySet = GameObject.Find("Boss").GetComponent<BossStrategyConfigGenerator>().GetRandomStrategyList();
    }
    private void ServerEnableActiveStrategies()
    {
        if (strategySet == null)
            return;
        
        strategySet.accumulationStrategy.enabled = true;
        strategySet.chargeStrategy.enabled = true;
        strategySet.devastationStrategy.enabled = true;
        strategySet.metricStrategy.enabled = true;
    }
    private void ClientEnableActiveStrategies()
    {

    }

}
