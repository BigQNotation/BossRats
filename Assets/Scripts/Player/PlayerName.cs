using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerName : NetworkBehaviour
{
    PlayerLoadHandler playerLoadHandler;
    private bool alreadySentUsername = false;

    private void Start()
    {
        playerLoadHandler = GameObject.Find("PlayerLoadHandler").GetComponent<PlayerLoadHandler>();
    }

    private void Update()
    {
        TrySetUsername();
    }
    private void TrySetUsername()
    {
        if (!isLocalPlayer || !playerLoadHandler.ArePlayersLoaded() || alreadySentUsername)
            return;

        alreadySentUsername = true;
        CmdSetUsername(PlayerPrefs.GetString("Username"));
    }
    [Command]
    private void CmdSetUsername(string username)
    {
        gameObject.GetComponent<PlayerStats>().playerName = username;
    }
}
