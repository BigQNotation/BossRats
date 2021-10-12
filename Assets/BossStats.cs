using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossStats : NetworkBehaviour
{
    [SyncVar]
    int bossHealth = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetBossHealth()
    {
        return bossHealth;
    }
    public void DecrementBossHealth(int healthDec)
    {
        bossHealth -= healthDec;
    }
}
