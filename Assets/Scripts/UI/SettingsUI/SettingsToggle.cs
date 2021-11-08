using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    [SerializeField] GameObject interfaceHandler;
    [SerializeField] GameObject settingsPrefab;
    public static bool isSettingActive = false;
    static  GameObject settings;

    private void Start()
    {
        interfaceHandler = GameObject.FindGameObjectWithTag("InterfaceHandler");
    }

    public void ToggleSettings()
    {
        if (!isSettingActive)
            CreateSettingsInterface();
        else
            DestroySettingsInterface();
        isSettingActive = !isSettingActive;
    }
    private void CreateSettingsInterface()
    {
        settings = interfaceHandler.GetComponent<InterfaceHandler>().AddInterfaceByPrefab(settingsPrefab);
        settings.GetComponentInChildren<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void DestroySettingsInterface()
    {
        Destroy(settings);
        interfaceHandler.GetComponent<InterfaceHandler>().RemoveActiveInterface();
    }


}
