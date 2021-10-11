using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricDistanceTraveled : BossMetricStrategy
{
    public override void ResetMetricFromPlayerRecords(GameObject playerObject)
    {
        playerObject.GetComponent<RecordDistanceTraveled>().ResetRecordedMetric();
    }

    public override void UpdateMetricFromPlayerRecords(GameObject playerObject)
    {
        metric += playerObject.GetComponent<RecordDistanceTraveled>().GetRecordedMetric();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
