using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeMeter : BossChargeStrategy
{
    [SerializeField]
    GameObject chargeMeterUI;


    // Start is called before the first frame update
    void Start()
    {
        this.TIMEWINDOW = 15;
        this.THRESHOLD = 5;
        chargeMeterUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SetChargeMeterUI();
        UpdateChargeTimers();
        RemoveExpiredCharges();    
    }

    private void SetChargeMeterUI()
    {
        chargeMeterUI.GetComponent<Text>().text = currentCharge.ToString();
    }

}
