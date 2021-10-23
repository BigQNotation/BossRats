using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerLoadHandler : NetworkBehaviour
{
    NetworkRoomManagerNew roomManager;
    [SyncVar] private bool arePlayersLoaded = false;

    public bool ArePlayersLoaded()
    {
        return arePlayersLoaded;
    }

    private void Start()
    {
        if (!isServer)
            return;
        roomManager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
    }
    private void Update()
    {
        if (!isServer)
            return;
        UpdatePlayerLoadStatus();
    }
    private void UpdatePlayerLoadStatus()
    {
        if (roomManager.roomSlots.Count == GameObject.FindGameObjectsWithTag("Player").Length)
            arePlayersLoaded = true;
    }
}
