using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class BossDevastationStrategy : NetworkBehaviour
{
    [SyncVar]
    public bool isActiveStrategy = false;

    protected float cooldownMax;
    protected float cooldownRemainder;
    protected bool readyToReset = false;

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public abstract void UseDevastation();
    protected abstract void EndDevastation();

    protected void StartDevastationTimer()
    {
        cooldownRemainder = cooldownMax;
    }
    protected void UpdateDevastationTimer()
    {
        if (cooldownRemainder > 0)
            cooldownRemainder -= Time.deltaTime;
    }
    protected bool IsDevastationTimerEnd()
    {
        if (cooldownRemainder <= 0)
            return true;
        return false;
    }
    
}
