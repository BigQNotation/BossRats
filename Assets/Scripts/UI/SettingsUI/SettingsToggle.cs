using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    [SerializeField] GameObject settingsPrefab;
    static GameObject settings;
    public static bool isSettingActive = false;

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
        settings = Instantiate(settingsPrefab);
        settings.GetComponentInChildren<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void DestroySettingsInterface()
    {
        Destroy(settings);
    }
}
