using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHeaderButtons : MonoBehaviour
{
    InterfaceHandler interfaceHandler;
    [SerializeField] GameObject roomLastGameInterfacePrefab;
    [SerializeField] GameObject roomSettingsInterfacePrefab;

    void Start()
    {
        interfaceHandler = GameObject.Find("HANDLERS").GetComponent<InterfaceHandler>();
    }
    public void LastGameButton()
    {
        interfaceHandler.AddInterfaceByPrefab(roomLastGameInterfacePrefab);
    }
    public void SettingsButton()
    {
        interfaceHandler.AddInterfaceByPrefab(roomSettingsInterfacePrefab);
    }
}
