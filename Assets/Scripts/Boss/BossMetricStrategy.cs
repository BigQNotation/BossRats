using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class BossMetricStrategy : NetworkBehaviour
{

    [SyncVar]
    public bool isActiveStrategy = false;

    protected float metric;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetMetric()
    {
        return metric;
    }
    public void ResetMetric()
    {
        metric = 0;
    }
    // Fetch metric data then reset player record metric to 0
    public abstract void UpdateMetricFromPlayerRecords(GameObject playerObject);
    public abstract void ResetMetricFromPlayerRecords(GameObject playerObject);

}
