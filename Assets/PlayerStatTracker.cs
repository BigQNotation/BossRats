using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerStatTracker : NetworkBehaviour
{
    GameObject playerLoadHandler;
    public static List<PlayerStat> playerStats = new List<PlayerStat>();

    public class PlayerStat
    {
        public PlayerStat(int id)
        {
            playerID = id;
        }
        public int playerID;
        public float playerDamageDealt = 0;
    }
    public static void UpdatePlayerStatTrackerDamage(int playerID, float damage)
    {
        foreach (PlayerStatTracker.PlayerStat playerStat in PlayerStatTracker.playerStats)
        {
            if (playerStat.playerID == playerID)
            {
                playerStat.playerDamageDealt += damage;
                Debug.Log("Player with ID " + playerStat.playerID + " has dealt a total of " + playerStat.playerDamageDealt + " DMG.");
            }
        }

    }

    private void Start()
    {
        playerStats = new List<PlayerStat>();
    }
    private void Update()
    {
        TryGetPlayerLoadHandler(); // one time

        if (playerLoadHandler == null || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;

        GeneratePlayerStats(); // one time

    }
    private void TryGetPlayerLoadHandler()
    {
        if (playerLoadHandler == null)
            playerLoadHandler = GameObject.Find("PlayerLoadHandler");
    }
    private void GeneratePlayerStats()
    {
        if (playerStats.Count == 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                playerStats.Add(new PlayerStat((int)players[i].GetComponent<NetworkIdentity>().netId));
            }
        }
    }
}