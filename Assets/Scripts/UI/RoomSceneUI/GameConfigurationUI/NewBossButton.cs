using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class NewBossButton : NetworkBehaviour
{
    LobbySettings lobbySettings;

    public void SwapBoss()
    {
        if (!lobbySettings.server)
            return;

        if (gameObject.GetComponent<Toggle>().isOn)
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 1); // KEEP OLD BOSS
        else
            PlayerPrefs.SetInt("PlayerDesiresNewBoss", 0); // NEW BOSS

        lobbySettings.newBoss = !gameObject.GetComponent<Toggle>().isOn;     
    }

    private void Start()
    {
        lobbySettings = GameObject.Find("LobbySettings").GetComponent<LobbySettings>();
        UpdateBossButtonText();
    }
    private void Update()
    {
        UpdateBossButtonText();
    }
    private void UpdateBossButtonText()
    {
        if (lobbySettings.newBoss)
            gameObject.GetComponent<Toggle>().isOn = false;
        else
            gameObject.GetComponent<Toggle>().isOn = true;
    }
}
