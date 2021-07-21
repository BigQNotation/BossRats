using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityShoot : Ability
{
    public GameObject projectilePrefab;
    public Transform projectileMount;
    public GameObject playerObject;

    public AbilityShoot()
    {
        this.abilityID = 15;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public override void UseAbility()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
    }

}


