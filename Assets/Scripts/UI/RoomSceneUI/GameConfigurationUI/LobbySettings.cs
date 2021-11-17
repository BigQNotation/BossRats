using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LobbySettings : NetworkBehaviour
{
    public bool server = false; // access isServer in local objects
    [SyncVar] public bool newBoss = false;

    private void Start()
    {
        if (!isServer)
            return;
        LoadNewBossOptionState();

    }
    private void Update()
    {
        // access isServer in local objects
        if (isServer)
            server = true;
        if (!isServer)
            server = false;

    }
    private void LoadNewBossOptionState()
    {
        if (PlayerPrefs.GetInt("PlayerDesiresNewBoss") == 0)
            newBoss = true;
        else
            newBoss = false;
    }
}
