using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStats : NetworkBehaviour
{
    [SyncVar]
    private int currentBossHealth = 1000;
    private int maxBossHealth = 1000;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetBossHealth()
    {
        return currentBossHealth;
    }
    public void DecrementBossHealth(int healthDec)
    {
        currentBossHealth -= healthDec;
    }
}
