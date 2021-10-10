using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAccumulationStrategy : NetworkBehaviour
{
    [SyncVar]
    public bool isActiveStrategy = false;

    private int stateCount;
    private int currentState = 0;
    private float accumulationTime = 3f;
    private float timeToNextAccumulation = 0;
    private float decumulationTime = 15f;
    private float timeToNextDecumulation = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void SetNumberOfStates(int states)
    {
        stateCount = states;
    }

    protected void IncreaseState()
    {
        if (currentState < stateCount)
            currentState++;
    }
    protected void DecreaseState()
    {
        if (currentState > 0)
            currentState--;
    }
    protected void ResetState()
    {
        currentState = 0;
    }
    protected int GetCurrentState()
    {
        return currentState;
    }
    public bool IsAccumulationIntervalReady()
    {
        if (timeToNextAccumulation <= 0)
            return true;
        return false;
    }
    public bool IsDecumulationIntervalReady()
    {
        if (timeToNextDecumulation <= 0)
            return true;
        return false;
    }
    public virtual void UseStrategy()
    {

    }
    public virtual void ResetStrategy()
    {

    }

 
    protected void UpdateTimeToNextAccumulation()
    {
        timeToNextAccumulation -= Time.deltaTime;
    }
    protected void ResetTimeToNextAccumulation()
    {
        timeToNextAccumulation = accumulationTime;
    }
    protected void UpdateTimeToNextDecumulation()
    {
        timeToNextDecumulation -= Time.deltaTime;
    }
    protected void ResetTimeToNextDecumulation()
    {
        timeToNextDecumulation = decumulationTime;
    }
    protected virtual void TryDecumulate()
    {

    }
}
