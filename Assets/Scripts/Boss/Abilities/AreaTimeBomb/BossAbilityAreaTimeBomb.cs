using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAbilityAreaTimeBomb : BossAbility
{
    public GameObject bombZonePrefab;
    


    private const int ID = 5;
    private const float cooldown = 10f;

    private Vector3 explosionLocation;

    public BossAbilityAreaTimeBomb()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }
    public override void UseAbility()
    {
        explosionLocation = FindPlayerLocation();
        CreateAreaTimeBombZone();
    }

    private void Start()
    {
        this.cooldownTimer = this.COOLDOWN;
    }
    private void Update()
    {

    }
    
    
    private Vector3 FindPlayerLocation()
    {
        return gameObject.GetComponent<BossAggroHandler>().GetPlayerWithAggro().position;
    }
    private void CreateAreaTimeBombZone()
    {
        GameObject timeBomb = Instantiate(bombZonePrefab, explosionLocation, transform.rotation);
        timeBomb.GetComponent<BossAbilityAreaTimeBombActiveZone>().explosionLocation = explosionLocation;
    }

}
