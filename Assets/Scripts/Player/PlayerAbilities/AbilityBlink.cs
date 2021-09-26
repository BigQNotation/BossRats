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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecrementCooldown();
    }

    public override void UseAbility(float clientXMousePos, float clientYMousePos)
    {
        
        playerObject.GetComponent<NetworkTransform>().ServerTeleport(new Vector2(clientXMousePos, clientYMousePos));
        //playerObject.transform.position = new Vector2(xPos, yPos);

    }

}
