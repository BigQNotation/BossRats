using Mirror;
using UnityEngine;

public abstract class BossDevastationStrategy : NetworkBehaviour
{
    [SyncVar]
    public bool isActiveStrategy = false;

    protected float cooldownMax;
    protected float cooldownRemainder = 0;
    protected bool devastationActive = false;

    protected float timeSpentInThreshold = 0;
    protected float timeSpentInThresholdBeforeDevastation = 5;

    public abstract void UseDevastation();
    public void UpdateTimeInDevastationThreshold()
    {
        timeSpentInThreshold += Time.deltaTime;
    }
    public void ResetTimeInDevastationThreshold()
    {
        timeSpentInThreshold = 0;
    }
    public bool HaveUsersSpentEnoughTimeInDevastationThresholdToTriggerDevastation()
    {
        if (timeSpentInThreshold >= timeSpentInThresholdBeforeDevastation)
            return true;
        else
            return false;
    }

    void Start() { }
    void Update() { }

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
