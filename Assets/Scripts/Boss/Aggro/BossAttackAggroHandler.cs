using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAttackAggroHandler : NetworkBehaviour
{
    [SerializeField] PlayerLoadHandler playerLoadHandler;
    private NetworkRoomManagerNew roomManager;
    private GameObject[] playerList;


    public Transform GetRandomPlayerTransform()
    {
        return playerList[Random.Range(0, playerList.Length)].transform;
    }

    protected void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
    }
    protected void Update()
    {
        TrySetPlayerList();
    }
    private void TrySetPlayerList()
    {
        if (!playerLoadHandler.ArePlayersLoaded())
            return;
        
        if (playerList == null || playerList.Length != roomManager.roomSlots.Count)
            playerList = GameObject.FindGameObjectsWithTag("Player");
    }

}
