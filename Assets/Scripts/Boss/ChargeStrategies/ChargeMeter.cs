using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class ChargeMeter : BossChargeStrategy
{

    // Start is called before the first frame update
    void Start()
    {
        this.TIMEWINDOW = 15;
        this.THRESHOLD = 5;

    }

    // Update is called once per frame
    void Update()
    {
        //SetChargeMeterUI();
        UpdateChargeTimers();
        RemoveExpiredCharges();    
    }

    public int GetCharge()
    {
        return currentCharge;
    }
    private void SetChargeMeterUI()
    {
        if (isServer)
        {
            GameObject.Find("ChargeMeterUI").GetComponent<ChargeMeterUI>().chargeText = gameObject.GetComponent<ChargeMeter>().GetCharge().ToString();
        }
        
    }
}
