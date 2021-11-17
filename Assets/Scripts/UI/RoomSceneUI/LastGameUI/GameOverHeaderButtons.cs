using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHeaderButtons : MonoBehaviour
{
    InterfaceHandler interfaceHandler;
    [SerializeField] GameObject roomSettingsInterfacePrefab;
    void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }
    public void LobbyButton()
    {
        interfaceHandler.RemoveActiveInterface();
    }
    public void SettingsButton()
    {
        interfaceHandler.RemoveActiveInterface();
        interfaceHandler.AddInterfaceByPrefab(roomSettingsInterfacePrefab);
    }
}
