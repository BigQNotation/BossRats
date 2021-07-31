using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Ability : NetworkBehaviour
{
    protected int abilityID { get; set; }
    protected float cooldownCap { get; set; }
    [SyncVar]
    public float cooldownRemainder;
    //public float cooldownRemainder { get; protected set; }

    public Ability()
    {
        abilityID = -1;
    }

    void Start()
    {
        ResetCooldown();
    }

    void Update()
    {
        
    }
    protected void DecrementCooldown()
    {
        cooldownRemainder = Mathf.Max(cooldownRemainder - Time.deltaTime, 0f);
    }
    public void ResetCooldown()
    {
        cooldownRemainder = cooldownCap;
    }
    public int GetAbilityID()
    {
        return abilityID;
    }
    public virtual void UseAbility()
    {

    }
    public bool AbilityReady()
    {
        if (cooldownRemainder <= 0)
            return true;
        else
            return false;
    }
}
