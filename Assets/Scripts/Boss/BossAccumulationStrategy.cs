using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAccumulationStrategy : MonoBehaviour
{
    private int stateCount;
    private int currentState = 0;
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

    public void IncreaseState()
    {
        if (currentState < stateCount)
            currentState++;
    }
    public void ResetState()
    {
        currentState = 0;
    }
    public int GetCurrentState()
    {
        return currentState;
    }
    public bool CheckMaxState()
    {
        if (currentState == stateCount)
            return true;
        else
            return false;
    }

    public virtual void UseStrategy()
    {

    }
    public virtual void ResetStrategy()
    {

    }

}
