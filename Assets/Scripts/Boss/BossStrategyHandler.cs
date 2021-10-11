using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStrategyHandler : NetworkBehaviour
{
    BossStrategyConfigGenerator.GeneratedStrategy strategySet;

    void Start()
    {
        
    }
    void Update()
    {
        if (!isServer)
            return;
        
        // Called only once
        CreateStrategy();
        EnableActiveStrategies();

        // Called every update
        if (strategySet == null)
            return;
        UpdatePlayerMetric();
        AddBossCharge(GetPlayerMetric());
        TryUseAccumulationStrategy();
        TryUseDevastationStrategy();
    }
    private void UpdatePlayerMetric()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            strategySet.metricStrategy.UpdateMetricFromPlayerRecords(players[i]);
            strategySet.metricStrategy.ResetMetricFromPlayerRecords(players[i]);

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
    private int GetPlayerMetric()
    {
        return (int)strategySet.metricStrategy.GetMetric();
    }
    private void AddBossCharge(int charge)
    {
        strategySet.chargeStrategy.AddCharge(charge);
        strategySet.metricStrategy.ResetMetric();
    }
    private void TryUseAccumulationStrategy()
    {
        if (strategySet.chargeStrategy.isAboveThresholdState())
        {
            strategySet.accumulationStrategy.UseStrategy();
        }
    }
    private void TryUseDevastationStrategy()
    {
        if (!strategySet.chargeStrategy.isAboveThresholdState())
        {
            strategySet.devastationStrategy.UseDevastation();
        }
    }
}
