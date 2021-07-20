using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
{

    [Header("Firing")]
    private KeyCode[] abilityKey = { KeyCode.Mouse0, KeyCode.Mouse1};
    public GameObject projectilePrefab;
    public Transform projectileMount;

    void Update()
    {
        if (!isLocalPlayer) return;

        if (Input.GetKeyDown(abilityKey[0]))
        {
            CmdAbilityOne();
        }
        if (Input.GetKeyDown(abilityKey[1]))
        {
            CmdAbilityTwo();
        }
    }

    // this is called on the server
    [Command]
    void CmdAbilityOne()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
        //RpcOnFire();
    }
    void CmdAbilityTwo()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileMount.position, transform.rotation);
        NetworkServer.Spawn(projectile);
        //RpcOnFire();
    }
    /*
    // this is called on the tank that fired for all observers
    [ClientRpc]
    void RpcOnFire()
    {
        animator.SetTrigger("Shoot");
    }
    */
}
