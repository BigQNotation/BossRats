using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BossAttackAggroHandler : NetworkBehaviour
{
    [SerializeField] PlayerLoadHandler playerLoadHandler;
    private NetworkRoomManagerNew roomManager;
    private GameObject[] playerList;

    [SyncVar] private Transform playerWithAggro;
    private float currentTimerToAggroSwap = .2f;
    private float maxTimerToAggroSwap = .2f;

    public Transform GetRandomPlayerTransform()
    {
        return playerWithAggro;
    }

    protected void Start()
    {
        roomManager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
    }
    protected void Update()
    {
        if (!isServer || !playerLoadHandler.ArePlayersLoaded())
            return;

        TrySetPlayerList();
        DecrementAggroSwapTimer();
        TryAggroSwap();
    }
    private void DecrementAggroSwapTimer()
    {
        currentTimerToAggroSwap -= Time.deltaTime;
    }
    private void TryAggroSwap()
    {
        if (currentTimerToAggroSwap <= 0)
        {
            currentTimerToAggroSwap = maxTimerToAggroSwap;
            playerWithAggro = playerList[Random.Range(0, playerList.Length)].transform;
        }
    }

    private void TrySetPlayerList()
    {
        if (playerList == null || playerList.Length != roomManager.roomSlots.Count)
            playerList = GameObject.FindGameObjectsWithTag("Player");
    }

}
