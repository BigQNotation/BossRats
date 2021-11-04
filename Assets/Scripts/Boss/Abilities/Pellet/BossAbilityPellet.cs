using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAbilityPellet : BossAbility
{

    public GameObject projectilePrefab;

    private const int ID = 1;
    private const float cooldown = 5f;

    public BossAbilityPellet()
    {
        this.abilityID = ID;
        this.COOLDOWN = cooldown;
    }
    public override void UseAbility()
    {
        Transform targetPlayer = FindPlayer();
        Vector2 directionToPlayer = GetVectorToPlayer(targetPlayer);
        CreatePellet(directionToPlayer);
    }

    private void Start()
    {
        this.cooldownTimer = this.COOLDOWN;
    }
    private Transform FindPlayer()
    {
        return gameObject.GetComponent<BossAttackAggroHandler>().GetRandomPlayerTransform();
    }
    private Vector2 GetVectorToPlayer(Transform target)
    {
        float x = target.position.x - gameObject.transform.position.x;
        float y = target.position.y - gameObject.transform.position.y;

        return new Vector2(x, y).normalized;
    }
    private void CreatePellet(Vector2 directionToPlayer)
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        projectile.GetComponent<BossAbilityPelletMovement>().AddForce(directionToPlayer);
    }
}
