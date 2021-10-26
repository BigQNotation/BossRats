using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilitySpeedboost : Ability
{
    public GameObject playerObject;

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
    public override void UseAbility(float clientXMousePos, float clientyMousePos)
    {
        if (!isServer || abilityActive)
            return;
        runSpeedVelocityNormal = playerObject.GetComponent<PlayerMovement>().runSpeed;
        playerObject.GetComponent<PlayerMovement>().runSpeed = runSpeedVelocityFast;
        abilityActive = true;
    }

    private void Start()
    {

    }
    private void Update()
    {
        DecrementCooldown();
        TryEndSpeedboost();
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
                playerObject.GetComponent<PlayerMovement>().runSpeed = runSpeedVelocityNormal;
                
            }
        }

        
    }
}
