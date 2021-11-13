using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RoomSceneInterface : NetworkBehaviour
{
    NetworkManager manager;
    public bool readyToPlay = false;
    public bool onlyReadyOnce = true;
    public bool startGame = false;
    private void Start()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
        manager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
    }

    public void ExitRoom()
    {
        // stop host if host mode
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            manager.StopHost();
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            manager.StopClient();
        }
    }
    public void ToggleReadyStatus()
    {
            if (!readyToPlay)
            {
                readyToPlay = true;
                GameObject.Find("ReadyText").GetComponent<Text>().text = "READY";
            }
            else
            {
                readyToPlay = false;
                GameObject.Find("ReadyText").GetComponent<Text>().text = "NOT READY";
            }

    }
    public void ToggleStartGame()
    {
        startGame = true;
    }
}
