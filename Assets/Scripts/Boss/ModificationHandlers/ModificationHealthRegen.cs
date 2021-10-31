using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModificationHealthRegen : MonoBehaviour
{
    private BossModifications bossModifications;
    private BossStats bossStats;

    private float healthRegenTimerCurrent;
    private readonly float healthRegenTimerMax = 3f;

    void Start()
    {
        healthRegenTimerCurrent = healthRegenTimerMax;
        bossModifications = GameObject.Find("Boss").GetComponent<BossModifications>();
        bossStats = GameObject.Find("Boss").GetComponent<BossStats>();
    }
    void Update()
    {
        HandleHealthRegeneration();
    }
    private void HandleHealthRegeneration()
    {
        UpdateRegenTimer();
        if (IsRegenReady())
            RegenHealth();
    }
    private void UpdateRegenTimer()
    {
        healthRegenTimerCurrent -= Time.deltaTime;
    }
    private bool IsRegenReady()
    {
        if (healthRegenTimerCurrent <= 0)
            return true;
        return false;
    }
    private void RegenHealth()
    {
        ResetRegenTimer();
        bossStats.IncrementBossHealth(bossModifications.healthRegeneration);   
    }
    private void ResetRegenTimer()
    {
        healthRegenTimerCurrent = healthRegenTimerMax;
    }
}
