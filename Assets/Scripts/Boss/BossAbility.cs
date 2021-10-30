using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbility : NetworkBehaviour
{
    protected int abilityID { get; set; }
    protected float COOLDOWN { get; set; }

    public float cooldownTimer;


    void Start()
    {
        ResetCooldown();
    }

    void Update()
    {
        
    }

    public virtual void UseAbility()
    {

    }

    public void ResetCooldown()
    {
        cooldownTimer = COOLDOWN;
    }

    public bool AbilityReady()
    {
        if (cooldownTimer <= 0)
            return true;
        else
            return false;
    }

    public int GetAbilityID()
    {
        return abilityID;
    }
    public void DecrementCooldown()
    {
        cooldownTimer = Mathf.Max(cooldownTimer - Time.deltaTime, 0f);
    }
}
