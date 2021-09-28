using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// charge strategy is a time window influenced by player actions metric.
// charge strategy has a threshold value in the time window;
// above and below the threshold each are different states.
// 

public class BossChargeStrategy : MonoBehaviour
{
    private float TIMEWINDOW; // must be set in inherited class
    private int THRESHOLD;    // must be set in inherited class
    private int currentCharge = 0;
    List<ChargeTimer> chargeTimers = new List<ChargeTimer>();

    public bool CheckThresholdState()
    {
        if (currentCharge >= THRESHOLD)
            return true;
        else
            return false;
    }
    public void AddCharge(int magnitude)
    {
        currentCharge += magnitude;
        chargeTimers.Add(new ChargeTimer(magnitude, TIMEWINDOW));
    }

    void Start()
    {


    }
    void Update()
    {
        UpdateChargeTimers();
        RemoveExpiredCharges();
    }

    private class ChargeTimer
    {
        public int charge;
        public float timeRemaining;

        public ChargeTimer(int mag, float time)
        {
            charge = mag;
            timeRemaining = time;
        }

        public bool CheckTimeUp()
        {
            if (timeRemaining <= 0)
                return true;
            else
                return false;
        }

    }
    private void RemoveExpiredCharges()
    {
        foreach (ChargeTimer timer in chargeTimers)
        {
            if (timer.timeRemaining <= 0)
                currentCharge -= timer.charge;
        }
        chargeTimers.RemoveAll(charge => charge.CheckTimeUp());
    }
    private void UpdateChargeTimers()
    {
        foreach (ChargeTimer timer in chargeTimers)
        {
            timer.timeRemaining -= Time.deltaTime; 
        }
    }
}
