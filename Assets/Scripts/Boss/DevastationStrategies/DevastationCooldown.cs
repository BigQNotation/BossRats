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
        if (readyToReset) // only allow UseDevastion while it isn't already in progress
            return;
        StartDevastationTimer();
        readyToReset = true;

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
        if (IsDevastationTimerEnd() && readyToReset)
            EndDevastation();
        else if (readyToReset)
        {
            UpdateCooldownDecreaseTimer();
            TryDecreaseCooldowns();
        }
            
    }
    protected override void EndDevastation()
    {
        readyToReset = false;
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
        BossAbility[] abilityList = gameObject.GetComponent<BossAbilityConfigGenerator>().GetRandomAbilityList();

        for (int i = 0; i < abilityList.Length; i++)
        {
            abilityList[i].cooldownTimer = abilityList[i].cooldownTimer / 2;
        }
    }

}
