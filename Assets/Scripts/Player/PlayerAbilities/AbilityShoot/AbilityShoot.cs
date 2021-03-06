using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityShoot : Ability
{
    public GameObject projectilePrefab;
    public Transform projectileMount;
    public GameObject playerObject;

    private const int ID = 15;
    private const float COOLDOWN = 5f;

    public AbilityShoot()
    {
        this.abilityID = ID;
        this.cooldownCap = COOLDOWN;
    }
    public override void UseAbility(float clientXMousePos, float clientyMousePos)
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        projectile.GetComponent<PlayerProjectileOrigin>().playerID = (int)gameObject.GetComponent<NetworkIdentity>().netId;
    }

    void Start()
    {
        
    }
    void Update()
    {
        DecrementCooldown();
    }   
}