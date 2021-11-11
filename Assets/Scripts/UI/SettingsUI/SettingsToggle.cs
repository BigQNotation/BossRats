using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    [SerializeField] GameObject interfaceHandler;
    [SerializeField] GameObject settingsPrefab;
    GameObject settings;

    private void Start()
    {
        interfaceHandler = GameObject.FindGameObjectWithTag("InterfaceHandler");
    }

    public void ToggleSettingsOn()
    {
        CreateSettingsInterface();
    }
    public void ToggleSettingsOff()
    {
        DestroySettingsInterface();
    }
    private void CreateSettingsInterface()
    {
        settings = interfaceHandler.GetComponent<InterfaceHandler>().AddInterfaceByPrefab(settingsPrefab);
        settings.GetComponentInChildren<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void DestroySettingsInterface()
    {
        interfaceHandler.GetComponent<InterfaceHandler>().RemoveActiveInterface();
    }


}
