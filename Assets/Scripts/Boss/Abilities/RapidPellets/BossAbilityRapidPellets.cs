using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityRapidPellets : BossAbility
{
    public GameObject projectilePrefab;

    private const int ID = 4;
    private const float cooldown = 10f;

    private readonly float force = 200f;
    private int numberofPelletsMax = 3;
    private int numberofPelletsCurrent = 0;
    private bool abilityActive = false;
    Vector2 directionToPlayer;
    private float pelletTimerCurrent = 0;
    private float pelletTimerMax = 0.5f;

    public BossAbilityRapidPellets()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }
    public override void UseAbility()
    {
        abilityActive = true;
    }

    private void Start()
    {
        this.cooldownTimer = this.COOLDOWN;
    }
    private void Update()
    {
        if (!abilityActive)
            return;

        Transform targetPlayer = FindPlayer();
        directionToPlayer = GetVectorToPlayer(targetPlayer);

        UpdateNextPelletTimer();
        if (IsNextPelletReady())
            CreatePellet();
        TryEndAbility();
    }
    private void UpdateNextPelletTimer()
    {
        pelletTimerCurrent -= Time.deltaTime;
    }
    private bool IsNextPelletReady()
    {
        if (pelletTimerCurrent <= 0)
            return true;
        return false;
    }
    private Transform FindPlayer()
    {
        return gameObject.GetComponent<BossAggroHandler>().GetPlayerWithAggro();
    }
    private Vector2 GetVectorToPlayer(Transform target)
    {
        float x = target.position.x - gameObject.transform.position.x;
        float y = target.position.y - gameObject.transform.position.y;

        return new Vector2(x, y).normalized;
    }
    private void CreatePellet()
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        projectile.GetComponent<BossAbilityRapidPelletsMovement>().AddForce(directionToPlayer);
        numberofPelletsCurrent++;
        pelletTimerCurrent = pelletTimerMax;
    }
    private void TryEndAbility()
    {
        if (numberofPelletsCurrent == numberofPelletsMax)
        {
            abilityActive = false;
            numberofPelletsCurrent = 0;
        }
            
    }
}
