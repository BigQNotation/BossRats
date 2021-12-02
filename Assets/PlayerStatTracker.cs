using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerStatTracker : NetworkBehaviour
{
    GameObject playerLoadHandler;
    //public static PlayerStat[] playerStats;
    public static List<PlayerStat> playerStats = new List<PlayerStat>();
    private void Start()
    {
        //playerLoadHandler = GameObject.Find("PlayerLoadHandler");
    }
    private void Update()
    {
        if (playerLoadHandler == null)
            playerLoadHandler = GameObject.Find("PlayerLoadHandler");

        if (playerLoadHandler == null || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;

        if (playerStats.Count == 0)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                playerStats.Add(new PlayerStat((int)players[i].GetComponent<NetworkIdentity>().netId));
            }       
        }
    }

    public class PlayerStat
    {
        public PlayerStat(int id)
        {
            playerID = id;
        }
        public int playerID;
        public int playerDamageDealt = 0;
    }
}