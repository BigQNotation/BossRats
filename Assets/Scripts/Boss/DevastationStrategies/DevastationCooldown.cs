using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevastationCooldown : BossDevastationStrategy
{
    private float cooldownDecreaseTimerCurrent;
    private readonly float cooldownDecreaseTimerMax = 2f;

    public override void UseDevastation()
    {
        if (devastationActive) // only allow UseDevastion while it isn't already in progress
            return;
        StartDevastationTimer();
        devastationActive = true;

        cooldownDecreaseTimerCurrent = cooldownDecreaseTimerMax;

    }
    void Start()
    {
        cooldownMax = 15;

    }
    void Update()
    {
        if (!isActiveStrategy)
            return;

        UpdateDevastationTimer();
        if (IsDevastationTimerEnd() && devastationActive)
            EndDevastation();
        else if (devastationActive)
        {
            UpdateCooldownDecreaseTimer();
            TryDecreaseCooldowns();
        }
            
    }
    protected override void EndDevastation()
    {
        devastationActive = false;
    }

    private void UpdateCooldownDecreaseTimer()
    {
        cooldownDecreaseTimerCurrent -= Time.deltaTime;
    }
    private void TryDecreaseCooldowns()
    {
        if (cooldownDecreaseTimerCurrent <= 0)
        {
            cooldownDecreaseTimerCurrent = cooldownDecreaseTimerMax;
            DecreaseCooldown();
        }
    }
    private void DecreaseCooldown()
    {

        BossAbility[] abilityList = gameObject.GetComponent<BossAbilityHandler>().GetAbilityList();
        
        for (int i = 0; i < abilityList.Length; i++)
        {
            abilityList[i].cooldownTimer = abilityList[i].cooldownTimer / 2;
        }
    }

}
