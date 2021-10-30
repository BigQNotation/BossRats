using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityBigSlowPellet : BossAbility
{

    public GameObject projectilePrefab;

    private const int ID = 3;
    private const float cooldown = 10f;
    

    public BossAbilityBigSlowPellet()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }
    private void Start()
    {
        this.cooldownTimer = this.COOLDOWN;
    }
    void Update()
    {
    }
    public override void UseAbility()
    {
        Transform targetPlayer = FindPlayer();
        Vector2 directionToPlayer = GetVectorToPlayer(targetPlayer);
        CreateBigSlowPellet(directionToPlayer);
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
    private void CreateBigSlowPellet(Vector2 directionToPlayer)
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        projectile.GetComponent<BossAbilityBigSlowPelletMovement>().AddForce(directionToPlayer);
    }
}
