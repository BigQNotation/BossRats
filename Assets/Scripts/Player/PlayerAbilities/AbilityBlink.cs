using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AbilityBlink : Ability
{
    private const int ID = 33;
    private const float COOLDOWN = 10f;

    [SyncVar]
    public GameObject playerObject;

    public AbilityBlink()
    {
        this.abilityID = ID;
        this.cooldownCap = COOLDOWN;
    }
    public override void UseAbility(float clientXMousePos, float clientYMousePos)
    {
        if (hasAuthority)
            CmdTeleport(clientXMousePos, clientYMousePos);
    }

    [Command]
    private void CmdTeleport(float clientXMousePos, float clientYMousePos)
    {
        playerObject.GetComponent<NetworkTransform>().ServerTeleport(new Vector2(clientXMousePos, clientYMousePos));
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        DecrementCooldown();
    }
}
