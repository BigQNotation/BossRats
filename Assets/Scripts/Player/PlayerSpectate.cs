using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSpectate : NetworkBehaviour
{
    PlayerCamera playerCamera;
    PlayerLoadHandler playerLoadHandler;
    PlayerStats playerStats;
    GameObject[] players;
    int currentSpectatedPlayer = 0;

    private void Start()
    {
        playerLoadHandler = GameObject.Find("PlayerLoadHandler").GetComponent<PlayerLoadHandler>();
        playerCamera = gameObject.GetComponent<PlayerCamera>();
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    private void Update() {

        if (!PlayerCanSpectate())
            return;

        GetPlayerObjects(); // do once
        UpdateSpectatedPlayer();
    }
    private bool PlayerCanSpectate()
    {
        if (!isLocalPlayer || !playerLoadHandler.ArePlayersLoaded() || (playerStats.GetCurrentPlayerHealth() > 0))
            return false;
        return true;
    }
    private void GetPlayerObjects()
    {
        if (players == null)
            players = GameObject.FindGameObjectsWithTag("Player");
    }
    private void UpdateSpectatedPlayer()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (currentSpectatedPlayer == players.Length - 1)
                currentSpectatedPlayer = 0;
            else
                currentSpectatedPlayer++;

            playerCamera.SetPlayerToSpectate(players[currentSpectatedPlayer].transform);
        }
    }
}

