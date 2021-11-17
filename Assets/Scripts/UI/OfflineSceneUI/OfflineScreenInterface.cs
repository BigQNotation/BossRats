using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineScreenInterface : MonoBehaviour
{
    NetworkManager manager;

    private void Start()
    {
        GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>().AddInterfaceByObject(gameObject);
        manager = GameObject.Find("RoomManager").GetComponent<NetworkRoomManagerNew>();
        GameOverUIHandler.isGameOverScene = false;
    }
    public void StartHost()
    {
        manager.StartHost();
    }
    public void StartClient()
    {
        manager.networkAddress = "localhost";
        manager.StartClient();
    }
    
    
}
