﻿using System.Collections;
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
        EnableChargeMeterUI();
        UpdateChargeTimers();
        RemoveExpiredCharges();    
    }

    public int GetCharge()
    {
        return currentCharge;
    }
    private void EnableChargeMeterUI()
    {
        gameObject.GetComponent<ChargeMeterUI>().enabled = true;
    }

}
