using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigurationUIToggle : MonoBehaviour
{
    [SerializeField] InterfaceHandler interfaceHandler;
    [SerializeField] GameObject gameConfigurationPrefab;
    static GameObject configurationInterface;

    public void CreateInterface()
    {
        configurationInterface = interfaceHandler.GetComponent<InterfaceHandler>().AddInterfaceByPrefab(gameConfigurationPrefab);
        Canvas[] canvi = configurationInterface.GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvi)
        {
            canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        }
    }
    public void DestroyInterface()
    {
        interfaceHandler.RemoveActiveInterface();
    }
}
