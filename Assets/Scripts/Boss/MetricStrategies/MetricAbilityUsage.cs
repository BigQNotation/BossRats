using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricAbilityUsage : BossMetricStrategy
{
    public override void ResetMetricFromPlayerRecords(GameObject playerObject)
    {
        playerObject.GetComponent<RecordAbilitiesUsed>().ResetRecordedMetric();
    }

    public override void UpdateMetricFromPlayerRecords(GameObject playerObject)
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
        if (!isActiveStrategy)
            return;
           
    }
}
