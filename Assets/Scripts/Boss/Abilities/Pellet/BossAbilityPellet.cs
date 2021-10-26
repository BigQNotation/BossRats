using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPellet : BossAbility
{

    public GameObject projectilePrefab;

    private const int ID = 1;
    private const float cooldown = 5f;

    public float force = 10f;

    public BossAbilityPellet()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }
    public override void UseAbility()
    {
        if (!isServer)
            return;

        Transform targetPlayer = FindPlayer();
        Vector2 directionToPlayer = GetVectorToPlayer(targetPlayer);
        CreateBigSlowPellet(directionToPlayer);
    }

    private void Start()
    {
        if (!isServer)
            return;
        this.cooldownTimer = this.COOLDOWN;
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
        projectile.GetComponent<BossAbilityPelletMovement>().velocity = directionToPlayer * force;
        NetworkServer.Spawn(projectile);
    }
}
