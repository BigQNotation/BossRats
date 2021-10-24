using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAggroHandler : NetworkBehaviour
{
    [SerializeField] GameObject playerLoadHandler;
    private Transform playerWithAggro;
    private GameObject[] playerList;
    private int[] aggroList;

    public Transform GetPlayerWithAggro()
    {
        return playerWithAggro;
    }
    public void AddPlayerAggro(GameObject player, int aggroAmount)
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            if (player == playerList[i])
            {
                aggroList[i] += aggroAmount;
            }
        }
    }

    private void Start()
    {
        playerWithAggro = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if (!isServer || !playerLoadHandler.GetComponent<PlayerLoadHandler>().ArePlayersLoaded())
            return;

        if (playerList == null)
            playerList = GetInitAllPlayers();

        if (aggroList == null)
            aggroList = GetInitAllAggro();

        UpdatePlayerWithAggro();

    }
    private GameObject[] GetInitAllPlayers()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }
    private int[] GetInitAllAggro()
    {
        int[] aggroList = new int[playerList.Length];
        for (int i = 0; i < playerList.Length; i++)
        {
            aggroList[i] = 0;
        }
        return aggroList;
    }
    private void UpdatePlayerWithAggro()
    {
        int mostAggro = 0;

        for (int i = 0; i < playerList.Length; i++)
        {
            if (aggroList[i] > mostAggro)
            {
                playerWithAggro = playerList[i].GetComponent<Transform>();
                mostAggro = aggroList[i];
            }
        }

    }
}
