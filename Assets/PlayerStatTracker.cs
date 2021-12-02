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
            Debug.Log("Creating player stats! (one time only fosho)");
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                Debug.Log(players[i].GetComponent<NetworkIdentity>().netId);
                playerStats.Add(new PlayerStat((int)players[i].GetComponent<NetworkIdentity>().netId));
                
                //playerStats[i].playerID = (int)players[i].GetComponent<NetworkIdentity>().netId;
                //Debug.Log("player stats set to: " + playerStats[i].playerID);
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