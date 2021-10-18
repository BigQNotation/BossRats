using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameOverSceneHandler : NetworkBehaviour
{
    [Scene]
    public string lobbyScene;
    GameObject[] players;

    private void Update()
    {
        if (!isServer)
            return;

        if (AreAllPlayersDead())
            ChangeSceneToLobby();
    }

    private bool AreAllPlayersDead()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        int deadPlayerCount = 0;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<PlayerStats>().GetCurrentPlayerHealth() <= 0)
                deadPlayerCount++;
        }

        if (deadPlayerCount == players.Length)
            return true;
        else
            return false;
    }
    private void ChangeSceneToLobby()
    {

        GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerExt>().ChangeScene();
        
        //NetworkClient.Ready();
        //NetworkManager.singleton.ServerChangeScene(lobbyScene);
    }
}
