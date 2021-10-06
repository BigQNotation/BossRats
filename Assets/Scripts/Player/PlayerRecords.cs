 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class PlayerRecords : NetworkBehaviour
{
    [SyncVar]
    protected float recordedMetric;

    // Start is called before the first frame update
    void Start()
    {
        recordedMetric = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    public abstract void UpdateRecordedMetric();

    public float GetRecordedMetric()
    {
        return recordedMetric;
    }
    public void ResetRecordedMetric()
    {
        recordedMetric = 0;
    }

}
