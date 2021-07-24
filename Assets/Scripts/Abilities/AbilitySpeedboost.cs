using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilitySpeedboost : Ability
{
    private const int ID = 90;
    private const float COOLDOWN = 10f;

    private float runSpeedVelocityFast = 15f;
    private float runSpeedVelocityNormal;

    private float abilityDuration = 3f;
    private float abilityDurationTimer = 0f;
    private bool  abilityActive = false;

    public AbilitySpeedboost()
    {
        this.abilityID = ID;
        this.cooldownCap = COOLDOWN;
    }

    void Start()
    {

    }

    void Update()
    {
        DecrementCooldown();
        TryEndSpeedboost();
    }

    public override void UseAbility()
    {
        runSpeedVelocityNormal = gameObject.GetComponent<PlayerMovement>().runSpeed;
        gameObject.GetComponent<PlayerMovement>().runSpeed = runSpeedVelocityFast;
        abilityActive = true;
    }

    private void TryEndSpeedboost()
    {
        if (abilityActive)
        {
            abilityDurationTimer += Time.deltaTime;
            if (abilityDurationTimer >= abilityDuration)
            {
                abilityActive = false;
                abilityDurationTimer = 0f;
                gameObject.GetComponent<PlayerMovement>().runSpeed = runSpeedVelocityNormal;
                
            }
        }

        
    }


}
