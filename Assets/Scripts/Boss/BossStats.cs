using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStats : NetworkBehaviour
{
    [SyncVar]
    private float currentBossHealth = 1000;
    private readonly float maxBossHealth = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public float GetBossHealth()
    {
        return currentBossHealth;
    }
    public float GetMaxBossHealth()
    {
        return maxBossHealth;
    }
    public void DecrementBossHealth(float healthDec)
    {
        currentBossHealth -= healthDec;
    }
    public void IncrementBossHealth(float healthInc)
    {
        currentBossHealth += healthInc;
    }
}
