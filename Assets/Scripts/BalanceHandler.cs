using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceHandler : MonoBehaviour
{
    // Arbitrary 
    private readonly float bossHealthPerPlayer = 1000;
    private readonly float playerHealth = 100;

    // Preference
    private readonly float matchLength = 10;
    private readonly float playerSecondsPerAbilityUsed = 2;
    private readonly float bossSecondsPerAbilityUsed = 2;

    // Estimate
    private readonly float playerAbilitiesMissedPerMinute = 10;
    private readonly float bossAbilitiesMissedPerMinute = 10;

    // Match dependent
    private int numberOfPlayersThisMatch;

    [SerializeField] GameObject playerLoadHandler;
    private bool alreadyUpdatedPlayerCount = false;

    private void Start()
    {
        DisplayPlayerDamagePerAbility();
    }
    private void Update()
    { 
        TryDisplayBossDamagePerAbility();
    }
    private void DisplayPlayerDamagePerAbility()
    {
        Debug.Log("BalanceHandler:" + GetPlayerDamagePerAbility().ToString() + " DMG / player ability.");
    }
    private void TryDisplayBossDamagePerAbility()
    {
        if (playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded() && !alreadyUpdatedPlayerCount)
        {
            numberOfPlayersThisMatch = GameObject.FindGameObjectsWithTag("Player").Length;
            alreadyUpdatedPlayerCount = true;
            Debug.Log("BalanceHandler:" + GetBossDamagePerAbility() + " DMG / boss ability.");
        }
    }
    private float GetPlayerDamagePerAbility()
    {
        return (GetEffectivePlayerDamagePerMinute() / (GetPlayerAbilitiesUsedPerMinute() - playerAbilitiesMissedPerMinute));
    }
    private float GetEffectivePlayerDamagePerMinute()
    {
        return (bossHealthPerPlayer / matchLength);
    }
    private float GetPlayerAbilitiesUsedPerMinute()
    {
        return 60 / playerSecondsPerAbilityUsed;
    }
    private float GetBossDamagePerAbility()
    {
        return (GetEffectiveBossDamagePerMinute() / (GetBossAbilitiesUsedPerMinute() - bossAbilitiesMissedPerMinute));
    }
    private float GetEffectiveBossDamagePerMinute()
    {
        return (playerHealth / matchLength) * numberOfPlayersThisMatch;
    }
    private float GetBossAbilitiesUsedPerMinute()
    {
        return 60 / bossSecondsPerAbilityUsed;
    }

}
