using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using System;

public class ChargeMeterUI : NetworkBehaviour
{
    [SyncVar]
    public String chargeText = "3";

    [SerializeField]
    GameObject chargeUI;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateChargeUI();
    }

    private void UpdateChargeUI()
    {
        if (isServer)
            chargeText = gameObject.GetComponent<ChargeMeter>().GetCharge().ToString();

        chargeUI.GetComponent<Text>().text = chargeText;
    }
}
