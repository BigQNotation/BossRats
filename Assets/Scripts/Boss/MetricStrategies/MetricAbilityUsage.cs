using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricAbilityUsage : BossMetricStrategy
{
    protected override void ResetMetricFromPlayerRecords(GameObject playerObject)
    {
        playerObject.GetComponent<RecordAbilitiesUsed>().ResetRecordedMetric();
    }

    protected override void UpdateMetricFromPlayerRecords(GameObject playerObject)
    {
        metric += playerObject.GetComponent<RecordAbilitiesUsed>().GetRecordedMetric();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // testing purposes, move to BossStrategyHandler
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            UpdateMetricFromPlayerRecords(players[i]);
            ResetMetricFromPlayerRecords(players[i]);
            
        }

        
        
    }
}
