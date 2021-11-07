using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineButtonStates : MonoBehaviour
{
    [SerializeField] GameObject offlineButtonCanvas;
    private void Update()
    {
        HandleOfflineButtons();
    }
    private void HandleOfflineButtons()
    {
        if (SettingsToggle.isSettingActive)
            offlineButtonCanvas.SetActive(false);
        else
            offlineButtonCanvas.SetActive(true);
    }
}
