using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordDistanceTraveled : PlayerRecords
{
    float distancePerUnitMetric = 20f; // balancing point
    float distanceTravelled = 0;
    Vector2 lastPosition;

    public override void UpdateRecordedMetric()
    {
        recordedMetric++;
    }

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        UpdateDistanceTravelled();
        TryUpdateRecordedMetric();
    }

    private void UpdateDistanceTravelled()
    {
        distanceTravelled += Vector2.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }
    private void TryUpdateRecordedMetric()
    {
        if (distanceTravelled >= distancePerUnitMetric)
        {
            distanceTravelled -= distancePerUnitMetric;
            UpdateRecordedMetric();
        }
    }
}
