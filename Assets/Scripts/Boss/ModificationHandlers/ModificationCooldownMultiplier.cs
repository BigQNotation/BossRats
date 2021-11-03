using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ModificationCooldownMultiplier : NetworkBehaviour
{
    private BossModifications bossModifications;
    private PlayerLoadHandler playerLoadHandler;
    private NetworkRoomManagerNew roomManager;

    void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
        bossModifications = GameObject.Find("Boss").GetComponent<BossModifications>();
        playerLoadHandler = GameObject.Find("PlayerLoadHandler").GetComponent<PlayerLoadHandler>();
    }

    
    void Update()
    {
        TrySetCooldownMultiplier();
    }
    private void TrySetCooldownMultiplier()
    {
        if (playerLoadHandler.ArePlayersLoaded())
            bossModifications.cooldownMultiplier = roomManager.roomSlots.Count;
    }
}
