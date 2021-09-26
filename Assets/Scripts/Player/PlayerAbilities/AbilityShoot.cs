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

    void Start()
    {
        
    }

    void Update()
    {
        DecrementCooldown();
    }
 
    public override void UseAbility(float clientXMousePos, float clientyMousePos)
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
    }
    
}


