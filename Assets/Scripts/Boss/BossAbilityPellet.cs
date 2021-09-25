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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isServer)
            return;

        DecrementCooldown();

        if (AbilityReady())
        {

            UseAbility();
            ResetCooldown();
        }
    }


    public override void UseAbility()
    {
        GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, transform.rotation);
        NetworkServer.Spawn(projectile);
    }

}
