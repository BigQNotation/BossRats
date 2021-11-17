using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSettingsHeaderButtons : MonoBehaviour
{
    InterfaceHandler interfaceHandler;
    [SerializeField] GameObject roomLastGameInterfacePrefab;
    void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }
    public void LastGameButton()
    {
        interfaceHandler.RemoveActiveInterface();
        interfaceHandler.AddInterfaceByPrefab(roomLastGameInterfacePrefab);
    }
    public void LobbyButton()
    {
        interfaceHandler.RemoveActiveInterface();
    }

}
