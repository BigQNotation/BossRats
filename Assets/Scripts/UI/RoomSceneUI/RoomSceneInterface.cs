using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RoomSceneInterface : NetworkBehaviour
{
    NetworkRoomManager manager;
    GameObject startGameButton;
    public bool readyToPlay = false;
    public bool onlyReadyOnce = true;
    public bool startGame = false;
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
        Debug.Log("ready: " + readyToPlay + onlyReadyOnce);
    }
    public void ToggleStartGame()
    {
        startGame = true;
    }

    private void Start()
    {
        AddRoomInterfaceToHandler();
        GetGameObjectsInScene();
        TryDisplayStartGameButton();
    }
    private void Update()
    {
        TryDisplayStartGameButton();
        HandleRoomSceneGUI();
    }
    private void AddRoomInterfaceToHandler()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
    }
    private void GetGameObjectsInScene()
    {   
        manager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
        startGameButton = GameObject.Find("StartGameButton");
    }
    private void TryDisplayStartGameButton()
    {
        if (isServer && manager.allPlayersReady)
            startGameButton.SetActive(true);
        else
            startGameButton.SetActive(false);
    }
    private void HandleRoomSceneGUI()
    {
        NetworkRoomManager room = NetworkManager.singleton as NetworkRoomManager;
        if (room)
        {
            if (!NetworkManager.IsSceneActive(room.RoomScene))
                return;

            GameObject[] roomPlayers = GameObject.FindGameObjectsWithTag("RoomPlayer");
            NetworkRoomPlayer roomPlayer = null;
            foreach (GameObject player in roomPlayers)
            {
                if (player.GetComponent<NetworkRoomPlayerExt>().isLocalPlayer)
                    roomPlayer = player.GetComponent<NetworkRoomPlayerExt>();
            }

            //NetworkRoomPlayer roomPlayer = GameObject.FindGameObjectWithTag("RoomPlayer").GetComponent<NetworkRoomPlayerExt>();
            
            if (room.allPlayersReady && NetworkServer.active && startGame)
                room.ServerChangeScene(room.GameplayScene);
            
            
            if (readyToPlay && onlyReadyOnce && isClient)
            {
                Debug.Log("calling1");
                roomPlayer.CmdChangeReadyState(true);
                onlyReadyOnce = false;
                Debug.Log("called2");

            }

            else if (!readyToPlay  && isClient && roomPlayer.readyToBegin == true)
            {
                roomPlayer.CmdChangeReadyState(false);
                onlyReadyOnce = true;
            }
        }
    }
}
