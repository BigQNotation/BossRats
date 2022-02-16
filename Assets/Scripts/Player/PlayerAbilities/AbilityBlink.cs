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

    [SerializeField] GameObject blinkCollisionCheckPrefab;
    GameObject collisionCheckObject;
    private bool collisionCheckStepActive = false;
    private float mouseX, mouseY;
    private int frameDelay = 0; 

    public AbilityBlink()
    {
        this.abilityID = ID;
        this.cooldownCap = COOLDOWN;
    }
    public override void UseAbility(float clientXMousePos, float clientYMousePos)
    {
        if (hasAuthority)
        {
            mouseX = clientXMousePos;
            mouseY = clientYMousePos;
            CreateCollisionCheckObject( clientXMousePos,  clientYMousePos);
            collisionCheckStepActive = true;
        }
           
    }
    private void CreateCollisionCheckObject(float clientXMousePos, float clientYMousePos)
    {
        // Create temp object at planned player teleport location
        collisionCheckObject = Instantiate(blinkCollisionCheckPrefab);
        collisionCheckObject.transform.position = (new Vector2(clientXMousePos, clientYMousePos));
    }

    [Command]
    private void CmdTeleport(float clientXMousePos, float clientYMousePos)
    {
        playerObject.GetComponent<NetworkTransform>().ServerTeleport(new Vector2(clientXMousePos, clientYMousePos));
    }
    [Command]
    private void CmdResetCooldown()
    {
        cooldownRemainder = 0;
    }
    private bool IsTeleportLocationOnWalkableTerrain()
    {
        if (GameObject.Find("Walls").GetComponent<UnityEngine.Tilemaps.TilemapCollider2D>().IsTouching(collisionCheckObject.GetComponent<BoxCollider2D>()))
        {
            
            return false;
        }
        return true;
    }
    private void TryFinishTeleport()
    {
        // wait 10 frames for collisionCheckObject to spawn and be able to collide.
        if (collisionCheckStepActive)
        {
            frameDelay++;
            if (frameDelay == 10)
            {
                if (IsTeleportLocationOnWalkableTerrain())
                    CmdTeleport(mouseX, mouseY);
                else
                    CmdResetCooldown();
                    
                collisionCheckStepActive = false;
                frameDelay = 0;
            }
        }
    }
    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        DecrementCooldown();
        if (!isLocalPlayer)
            return;
        TryFinishTeleport();
        
    }
   
}
